using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MachineGun : PlayerShoot
{
    private bool _fireContinously;
    private bool _fireSingle;
    [SerializeField] AudioSource machineGunAudio;
    [SerializeField] AudioSource machineGunReloadAudio;

    // Update is called once per frame
    protected override void Update()
    {
        if(gm.isPaused == true) {
            return;
        }
        if(_fireContinously && haveAmmo){
            float timeSinceLastFire = Time.time - _lastFireTime; // Fix close shot bullets.

            if(timeSinceLastFire >= _timeBetweenShots) {
                machineGunAudio.Play();
                FireBullet();
                _lastFireTime = Time.time;
                //_fireSingle = false;
            }
        }
        if (haveAmmo == false) {
            UpdateButtonOpacity(KeyCode.R, rButton);
            Reload();
        }

        // if (isReloading == true) {
        //     machineGunReloadAudio.Play();
        // }
    }

    protected override void Reload() {
        // Show ReloadPopUp
        ReloadPopUp(reloadText, rButton, rText);
        if(Input.GetKeyDown(KeyCode.R) && !isReloading) {
            machineGunReloadAudio.Play();
            isReloading = true;
            startTime = Time.time;
            Debug.Log("Player is now reloading...");
        }
        if (isReloading) {
            if (Time.time - startTime > reloadTime) {
                haveAmmo = true;
                ammoInClip = magazineSize;
                ammoLeftTotal -= magazineSize;
                isReloading = false;
                // Hide ReloadPopUp
                ReloadPopUp(reloadText, rButton, rText);
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

