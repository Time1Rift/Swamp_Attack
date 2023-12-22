using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private int _reward;

    private Player _targetPlayer;

    public Player TargetPlayer => _targetPlayer;
    public int Reward => _reward;

    public event Action<Enemy> Died;

    public void Init(Player targetPlayer) => _targetPlayer = targetPlayer;
    
    public void TakeDamage(int damage)
    {
        _health = Mathf.Clamp(_health - damage, 0, _health);

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
        Died?.Invoke(this);
    }
}