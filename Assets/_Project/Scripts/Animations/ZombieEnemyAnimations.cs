using UnityEngine;

public class ZombieEnemyAnimations : MonoBehaviour
{

    private Animator _animator;
    private ZombieEnemy _enemy;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<ZombieEnemy>();
    }

    private void Start()
    {
        _enemy.OnStateChanged += AnimationParamHandler;
    }

    private void AnimationParamHandler(EnemyState currentState, EnemyState newState)
    {
        switch (newState)
        {
            case EnemyState.Idle:
                _animator.SetBool("isWaiting", true);
                _animator.SetBool("isPlayerInSight", false);
                break;
            case EnemyState.Walking:
                _animator.SetBool("isWaiting", false);
                break;
            case EnemyState.Running:
                _animator.SetBool("isPlayerInSight", true);
                break;
        }
    }

}
