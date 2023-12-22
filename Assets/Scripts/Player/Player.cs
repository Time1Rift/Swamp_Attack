using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private List<Weapon> _weapons = new();
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private UnityEvent _shoot;

    private float _currentHealth;
    private Weapon _currentWeapon;
    private int _currentWeaponNumber = 0;
    private Animator _animator;

    public int Money { get; private set; }

    public event Action<int, int> HealthChenged;
    public event Action<int> MoneyChenged;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _currentHealth = _maxHealth;
        ChangedWeapon(_weapons[_currentWeaponNumber]);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _shoot?.Invoke();
            _animator.Play(PlayerAnimator.Shoot);
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    public void NextWeapon()
    {
        if (_currentWeaponNumber == _weapons.Count - 1)
            _currentWeaponNumber = 0;
        else
            _currentWeaponNumber++;

        ChangedWeapon(_weapons[_currentWeaponNumber]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponNumber == 0)
            _currentWeaponNumber = _weapons.Count - 1;
        else
            _currentWeaponNumber--;

        ChangedWeapon(_weapons[_currentWeaponNumber]);
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChenged?.Invoke(Money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        _weapons.Add(weapon);
        MoneyChenged?.Invoke(Money);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _currentHealth);
        HealthChenged?.Invoke((int)_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
            Die();
    }

    private void ChangedWeapon(Weapon weapon) => _currentWeapon = weapon;

    private void Die()
    {
        Destroy(gameObject);
    }
}