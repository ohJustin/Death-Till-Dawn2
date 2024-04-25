using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MachineGun : PlayerShoot
{
    private bool _fireContinously;
    private bool _fireSingle;
    [SerializeField] AudioSource machineGunAudio;

    // Update is called once per frame
    protected override void Update()
    {
        if(_fireContinously && haveAmmo){
            float timeSinceLastFire = Time.time - _lastFireTime; // Fix close shot bullets.

            if(timeSinceLastFire >= _timeBetweenShots) {
                machineGunAudio.Play();
                FireBullet();
                _lastFireTime = Time.time;
                //_fireSingle = false;
            }
        }
    }


    private void OnFire(InputValue inputValue){
        _fireContinously = inputValue.isPressed;
        // if(inputValue.isPressed){
        //     _fireSingle = true;
        // }
    }

}

