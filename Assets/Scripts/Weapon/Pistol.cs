using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(BulletPrefab, shootPoint);
    }
}