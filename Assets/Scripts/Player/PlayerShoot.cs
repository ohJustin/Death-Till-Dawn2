using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] protected GameObject _bulletPrefab; 
    [SerializeField] protected float _bulletSpeed; 
    [SerializeField] protected Transform _gunOffset;
    [SerializeField] protected float _timeBetweenShots;
    [SerializeField] public int ammoLeftTotal;
    [SerializeField] public int ammoInClip;
    [SerializeField] AudioSource pistolAudio;

    [SerializeField] protected int magazineSize;

    [SerializeField] protected float reloadTime;

    [SerializeField] public Sprite icon;                           //CHANGE HEREHERHERHEHREHREHRHERHERH
    [SerializeField] protected TextMeshProUGUI magazineSizeText;
    [SerializeField] protected TextMeshProUGUI magazineCountText;

    protected float _lastFireTime;

    protected bool haveAmmo = true;

    protected float startTime;

    protected GameManager gm;

    void Start() {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }



    // Update is called once per frame
    protected virtual void Update()
    {
        if(gm.isPaused == true) {
            return;
        }

        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // Check for left mouse button or spacebar press
        {
            if (Time.time - _lastFireTime >= _timeBetweenShots && haveAmmo)
            {
                pistolAudio.Play();
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
        UpdateAmmo();
    }

    protected void UpdateAmmo() {
        ammoInClip--;
        if(ammoLeftTotal == 0 && ammoInClip == 0) {
            haveAmmo = false;
            return;
        }
        if (ammoInClip == 0) {
            startTime = Time.time;
            haveAmmo = false;
            Reload();
        }
    }

    protected void Reload() {
        if(Time.time - startTime > reloadTime) {
            haveAmmo = true;
            ammoInClip = magazineSize;
            ammoLeftTotal -= magazineSize;
            return;
        }
        else {
            Invoke("Reload", .1f);
        }
    }


}

