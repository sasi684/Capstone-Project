using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public abstract class BaseEnemy : MonoBehaviour
{
    [Tooltip("Determines the time the agent waits before moving to next waypoint.")]
    [SerializeField] protected float _waitTime = 3f;
    [Tooltip("The waypoints where the monster patrols to.")]
    [SerializeField] protected Transform[] _waypoints;
    [Tooltip("After this amount of time passes, the enemy will return in Idle mode.")]
    [SerializeField] protected float _runToIdleTime = 8f;
    [Tooltip("The refresh rate to update the path while chasing the player.")]
    [SerializeField] protected float _runUpdateTime = 0.3f;

    protected NavMeshAgent _agent;
    protected FieldOfView _fieldOfView;

    protected Coroutine _waitingCoroutine;
    protected bool _isWaiting;
    protected int _index;

    protected Coroutine _chasingCoroutine;
    protected float _lastPlayerInSight;

    public event Action<EnemyState, EnemyState> OnStateChanged;
    protected EnemyState _currentState;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _fieldOfView = GetComponent<FieldOfView>();
    }

    private void Update()
    {
        Debug.Log(_currentState);
        switch (_currentState)
        {
            case EnemyState.Idle:
                IdleUpdate();
                break;
            case EnemyState.Walking:
                WalkingUpdate();
                break;
            case EnemyState.Running:
                RunningUpdate();
                break;
        }
    }

    protected abstract void IdleUpdate();
    protected abstract void WalkingUpdate();
    protected abstract void RunningUpdate();

    protected void ChangeState(EnemyState newState)
    {
        OnStateChanged?.Invoke(_currentState, newState);

        OnExitState(_currentState);
        _currentState = newState;
        OnEnterState(newState);
    }

    private void OnExitState(EnemyState currentState)
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                OnExitIdle();
                break;
            case EnemyState.Walking:
                OnExitWalking();
                break;
            case EnemyState.Running:
                OnExitRunning();
                break;
        }
    }
    protected abstract void OnExitIdle();
    protected abstract void OnExitWalking();
    protected abstract void OnExitRunning();

    private void OnEnterState(EnemyState newState)
    {
        switch (newState)
        {
            case EnemyState.Idle:
                OnEnterIdle();
                break;
            case EnemyState.Walking:
                OnEnterWalking();
                break;
            case EnemyState.Running:
                OnEnterRunning();
                break;
        }
    }
    protected abstract void OnEnterIdle();
    protected abstract void OnEnterWalking();
    protected abstract void OnEnterRunning();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            ScreenFader.Instance.StartFadeToOpaque(ChangeSceneToCaught);
        }
    }

    private void ChangeSceneToCaught()
    {
        SceneManager.LoadScene("Caught");
        ScreenFader.Instance.StartFadeToTransparent();
    }
}
