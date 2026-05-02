using System.Collections;
using UnityEngine;

public class ZombieEnemy : BaseEnemy
{
    [Header("Sounds List")]
    [SerializeField] private AudioClip[] _idleSounds;
    [SerializeField] private AudioClip[] _followSounds;

    private void Start()
    {
        _currentState = EnemyState.Idle;
    }

    protected override void IdleUpdate()
    {
        if (CheckForPlayer())
            return;

        if (_isWaiting)
            return;

        _waitingCoroutine = StartCoroutine(WaitingCoroutine());

        if (Time.time - _lastIdleSound > _idleSoundUpdateTime)
        {
            PlaySound(_idleSounds);
            _lastIdleSound = Time.time;
        }
    }

    protected override void WalkingUpdate()
    {
        if (CheckForPlayer())
            return;

        if (_waypoints == null)
            return;

        if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
        {
            ChangeState(EnemyState.Idle);
        }

        if (Time.time - _lastIdleSound > _idleSoundUpdateTime)
        {
            PlaySound(_idleSounds);
            _lastIdleSound = Time.time;
        }
    }

    protected override void RunningUpdate()
    {
        if (Time.time - _lastPlayerInSight > _runToIdleTime)
        {
            ChangeState(EnemyState.Idle);
            return;
        }

        if (_fieldOfView.IsPlayerInSight())
            _lastPlayerInSight = Time.time;

        if (_chasingCoroutine == null)
            _chasingCoroutine = StartCoroutine(ChasingCoroutine());

        if (Time.time - _lastFollowSound > _followSoundUpdateTime)
        {
            PlaySound(_followSounds);
            _lastFollowSound = Time.time;
        }
    }

    protected override void OnExitIdle()
    {
        
    }

    protected override void OnExitWalking()
    {

    }

    protected override void OnExitRunning()
    {
        _agent.speed /= 5;
    }

    protected override void OnEnterIdle()
    {
        if (_waitingCoroutine != null)
        {
            StopCoroutine(_waitingCoroutine);
            _waitingCoroutine = null;
        }

        if (_chasingCoroutine != null)
        {
            StopCoroutine(_chasingCoroutine);
            _chasingCoroutine = null;
        }

        PlaySound(_idleSounds);
        _lastIdleSound = Time.time;
    }

    protected override void OnEnterWalking()
    {
        
    }

    protected override void OnEnterRunning()
    {
        _agent.speed *= 5;

        PlaySound(_followSounds);
        _lastFollowSound = Time.time;
    }

    private IEnumerator WaitingCoroutine()
    {
        _isWaiting = true;
        _agent.isStopped = true;
        yield return new WaitForSeconds(_waitTime);

        _agent.SetDestination(_waypoints[_index].position);
        _index = (_index + 1) % _waypoints.Length;

        _agent.isStopped = false;
        _isWaiting = false;
        _waitingCoroutine = null;

        ChangeState(EnemyState.Walking);
    }

    private bool CheckForPlayer()
    {
        if (_fieldOfView.IsPlayerInSight())
        {
            _lastPlayerInSight = Time.time;
            ChangeState(EnemyState.Running);
            return true;
        }
        return false;
    }

    private IEnumerator ChasingCoroutine()
    {
        var waitTime = new WaitForSeconds(_runUpdateTime);
        while (true)
        {
            _agent.SetDestination(_fieldOfView.Player.position);
            yield return waitTime;
        }
    }
}
