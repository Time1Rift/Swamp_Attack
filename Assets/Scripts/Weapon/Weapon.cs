using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet BulletPrefab;

    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyet;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyet => _isBuyet;

    public void Buy() => _isBuyet = true;

    public abstract void Shoot(Transform shootPoint);
}