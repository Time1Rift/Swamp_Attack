using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChenged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.HealthChenged -= OnValueChanged;
    }
}