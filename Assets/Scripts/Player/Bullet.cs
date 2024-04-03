using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Camera _camera;

    [SerializeField]
    private int bulletDmg = 1;

    private void Awake () {
        _camera = Camera.main;
    }

    private void Update() {
        DestroyWhenOffScreen();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.GetComponent<EnemyMovement>()){ 

            // If the collision obj in parameters has EnemyMovement, then its a zombie. So we can destroy it and the bullet.

            //I changed the bullet to dmg enemies using the new health system
            collision.gameObject.GetComponent<EnemyBase>().TakeDmg(bulletDmg);
            if(collision.gameObject.GetComponent<EnemyBase>().enemyHealth.Health == 0) {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);

        }
    }

    private void DestroyWhenOffScreen() {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0 || 
            screenPosition.x > _camera.pixelWidth ||
            screenPosition.y < 0 ||
            screenPosition.y > _camera.pixelHeight) {
                Destroy(gameObject);
            }
    }

}
