using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShotGun : PlayerShoot
{
    [SerializeField] private int _numBullets = 3; // Number of bullets to shoot
    [SerializeField] private float _spreadAngle = 30f; // Angle of bullet spread
    [SerializeField] private float _shotgunCooldown = 0.5f; // Cooldown period for the shotgun
    [SerializeField] AudioSource shotgunAudio;
    private bool _canFire = true;

    protected override void Update()
    {
        // Check for shotgun input
        if (IsFireButtonDown() && _canFire && haveAmmo)
        {   
            shotgunAudio.Play();
            Fire();
            _canFire = false;
            Invoke("ResetFire", _shotgunCooldown); // Reset fire after cooldown
            UpdateAmmo();
        }
        
        if (haveAmmo == false) {
            UpdateButtonOpacity(KeyCode.R, rButton);
            Reload();
        }
    }

    private void ResetFire()
    {
        _canFire = true;
    }

    private bool IsFireButtonDown()
    {
        // Check if left mouse button or spacebar is pressed
        return Mouse.current.leftButton.wasPressedThisFrame || Keyboard.current.spaceKey.wasPressedThisFrame;
    }

    private void Fire()
    {
        for (int i = 0; i < _numBullets; i++)
        {
            // Calculate random angle within the spread angle range
            float randomAngle = Random.Range(-_spreadAngle / 2f, _spreadAngle / 2f);

            // Calculate direction for each bullet
            Vector3 direction = Quaternion.Euler(0, 0, randomAngle) * transform.up;

            // Instantiate bullet
            GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, Quaternion.identity);
            Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
            rigidbody.velocity = _bulletSpeed * direction;
        }
    }
}

