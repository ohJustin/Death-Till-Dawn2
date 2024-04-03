using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadPool : MonoBehaviour
{

    [SerializeField]
    private int dmg = 1;

    [SerializeField]
    private float dmgTime = 0.5f;

    [SerializeField]

    private float lifeTime = 5f;

    private bool isTouching;

    private GameObject plr;
    
    private float birthTime;



    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.GetComponent<PlayerMovement>()){ 
            isTouching = true;
            plr = collision.gameObject;
            Invoke("DmgPlayer", dmgTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.GetComponent<PlayerMovement>()){ 
            isTouching = false;
        }
    }

    public void DmgPlayer() {
        if(isTouching) {
            plr.GetComponent<PlayerBase>().TakeDmg(dmg);
            Invoke("DmgPlayer", dmgTime);
        }
    }

    void Start() {
        birthTime =Time.time;
    }

    void Update() {
        if(Time.time - birthTime > lifeTime) {
            Destroy(gameObject);
        }
    }
}
