using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private float _lastAttackTime;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_lastAttackTime < 0)
        {
            _lastAttackTime = _delay;
            _animator.Play(EnemyAnimator.Attack);
            TargetPlayer.TakeDamage(_damage);
        }

        _lastAttackTime -= Time.deltaTime;
    }
}