using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _template;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
            AddItem(_weapons[i]);

        gameObject.SetActive(false);
    }

    private void AddItem(Weapon weapon)
    {
        var weaponView = Instantiate(_template, _itemContainer.transform);
        weaponView.Render(weapon);
        weaponView.SellButtonClick += OnSellButtonClick;
    }

    private void OnSellButtonClick(Weapon weapon, WeaponView weaponView)
    {
        TrySellWeapon(weapon, weaponView);
    }

    private void TrySellWeapon(Weapon weapon, WeaponView weaponView)
    {
        if (_player.Money >= weapon.Price)
        {
            _player.BuyWeapon(weapon);
            weapon.Buy();
            weaponView.SellButtonClick -= OnSellButtonClick;
        }
    }
}