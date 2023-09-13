using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _weaponTransform;

    private Vector2 _direction = new Vector2(1, 0);

    public void Shoot()
    {
        Bullet bullet = Instantiate(_bullet, _weaponTransform.position, Quaternion.identity);
        bullet.SetDirection(_direction);
    }
}
