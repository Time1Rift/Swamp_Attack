using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private Button _sellButton;

    private Weapon _weapon;

    public event Action<Weapon, WeaponView> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnSellButtonClick);
        _sellButton.onClick.AddListener(TrySellWeapon);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnSellButtonClick);
        _sellButton.onClick.RemoveListener(TrySellWeapon);
    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;
        _icon.sprite = _weapon.Icon;
        _label.text = _weapon.Label;
        _price.text = _weapon.Price.ToString();
    }

    private void TrySellWeapon()
    {
        if (_weapon.IsBuyet)
            _sellButton.interactable = false;
    }

    private void OnSellButtonClick()
    {
        SellButtonClick?.Invoke(_weapon, this);
    }
}