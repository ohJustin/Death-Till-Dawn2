using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.GetComponent<EnemyMovement>()){ 

            // If the collision obj in parameters has EnemyMovement, then its a zombie. So we can destroy it and the bullet.
            Destroy(collision.gameObject); //Remove Enemy
            Destroy(gameObject); // Remove Bullet

        }
    }

}
