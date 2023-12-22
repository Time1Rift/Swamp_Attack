using TMPro;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _money;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _money.text = _player.Money.ToString();
        _player.MoneyChenged += OnMoneyChenged;
    }

    private void OnDisable()
    {
        _player.MoneyChenged += OnMoneyChenged;
    }

    private void OnMoneyChenged(int money) => _money.text = money.ToString();
}