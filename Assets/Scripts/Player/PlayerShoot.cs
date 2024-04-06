using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] protected GameObject _bulletPrefab; 
    [SerializeField] protected float _bulletSpeed; 
    [SerializeField] protected Transform _gunOffset;
    [SerializeField] protected float _timeBetweenShots;
    [SerializeField] protected int magazineCount;
    [SerializeField] protected int magazineSize;

    [SerializeField] public Sprite icon;                           //CHANGE HEREHERHERHEHREHREHRHERHERH
    [SerializeField] protected TextMeshProUGUI magazineSizeText;
    [SerializeField] protected TextMeshProUGUI magazineCountText;

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

    protected void FireBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = _bulletSpeed * transform.up;
    }

}

