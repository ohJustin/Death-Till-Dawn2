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
    [SerializeField] AudioSource pistolReloadAudio;

    [SerializeField] protected int magazineSize;

    [SerializeField] protected float reloadTime;

    [SerializeField] public Sprite icon;                           //CHANGE HEREHERHERHEHREHREHRHERHERH
    [SerializeField] protected TextMeshProUGUI magazineSizeText;
    [SerializeField] protected TextMeshProUGUI magazineCountText;

    [SerializeField] public TextMeshProUGUI reloadText;
    [SerializeField] public Button rButton;
    [SerializeField] public TextMeshProUGUI rText;

    protected float _lastFireTime;

    protected bool haveAmmo = true;

    protected float startTime;
    protected bool isReloading;

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
        if (haveAmmo == false) {
            UpdateButtonOpacity(KeyCode.R, rButton);
            Reload();
        }

        // if (isReloading == true) {
        //     pistolReloadAudio.Play();
        // }
        
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
        else if (ammoInClip == 0) {
            haveAmmo = false;
        }
    }

    protected virtual void Reload() {
        // Show ReloadPopUp
        ReloadPopUp(reloadText, rButton, rText);
        if(Input.GetKeyDown(KeyCode.R) && !isReloading) {
            pistolReloadAudio.Play();
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


    public void ReloadPopUp(TextMeshProUGUI text, Button button, TextMeshProUGUI textButton)
    {
        if (haveAmmo == false)
        {
            // Out of Ammo, Show user Reload PopUp
            // Make text visible
            text.color = new Color32(255, 0, 0, 255);
            // Make button visible
            Color buttonColor = button.image.color;
            buttonColor.a = 0.5f;
            button.image.color = buttonColor;
            // Make button text visible
            textButton.color = new Color32(255, 0, 0, 255);
        }
        else if (haveAmmo == true)
        {
            // Ammo is now full
            // Make text disappear
            text.color = new Color32(255, 0, 0, 0);
            // Make Button disappear
            Color buttonColor = button.image.color;
            buttonColor.a = 0f;
            button.image.color = buttonColor;
            // Make button text disappear
            textButton.color = new Color32(255, 0, 0, 0);
        }
    }

    protected void UpdateButtonOpacity(KeyCode keyCode, Button button)
    {
        if (Input.GetKeyDown(keyCode))
        {
            // Key is pressed, change opacity to 1
            Color buttonColor = button.image.color;
            buttonColor.a = 1f;
            button.image.color = buttonColor;
        }
        else if (Input.GetKeyUp(keyCode))
        {
            // Key is released, change opacity back to 0.5 (or any other desired value)
            Color buttonColor = button.image.color;
            buttonColor.a = 0.5f;
            button.image.color = buttonColor;
        }
    }

}

