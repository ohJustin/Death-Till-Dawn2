using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField]
    private GameObject _bulletPrefab; // Player needs to be able to fire multiple bullets.

    [SerializeField]
    private float _bulletSpeed; // Adjust later with new weapons?

    

    [SerializeField]
    private Transform _gunOffset;

    [SerializeField]
    private float _timeBetweenShots;

    private bool _fireContinously;

    private bool _fireSingle;
    private float _lastFireTime;


    // Update is called once per frame
    void Update()
    {
        if(_fireContinously || _fireSingle){
            float timeSinceLastFire = Time.time - _lastFireTime; // Fix close shot bullets.

            if(timeSinceLastFire >= _timeBetweenShots){

            FireBullet();
            _lastFireTime = Time.time;
            _fireSingle = false;
            }

        }


        
    }


    private void OnFire(InputValue inputValue){
        _fireContinously = inputValue.isPressed;

        if(inputValue.isPressed){
            _fireSingle = true;
        }
    }

    private void FireBullet(){
        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();

        rigidbody.velocity = _bulletSpeed * transform.up;
    }


}
