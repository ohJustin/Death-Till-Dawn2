using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] protected GameObject _bulletPrefab; 
    [SerializeField] protected float _bulletSpeed; 
    [SerializeField] protected Transform _gunOffset;
    [SerializeField] protected float _timeBetweenShots;

    protected float _lastFireTime;

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space)) // Check for left mouse button or spacebar press
        {
            if (Time.time - _lastFireTime >= _timeBetweenShots)
            {
                FireBullet();
                _lastFireTime = Time.time;
            }
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = _bulletSpeed * transform.up;
    }
}

