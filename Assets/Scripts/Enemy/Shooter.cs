using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Shooter : EnemyBase
{
    // Start is called before the first frame update

    [SerializeField] private float throwDist = 5f;
    override protected void Start()
    {
        maxHealth = 200;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyHealth = new HealthSystem(maxHealth, maxHealth);
        enemyHealthBar = GameObject.FindGameObjectWithTag("BossHealth").GetComponentInChildren<HealthBar>();
        enemyHealthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth.Health == 0) {
            SceneManager.LoadScene(4);
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.GetComponent<EnemyMovement>()){
            EnemyMovement temp = collision.GetComponent<EnemyMovement>();
            Debug.Log("Here");
            temp.endPos = new Vector3(collision.transform.position.x + (transform.up.x * throwDist), collision.transform.position.y + (transform.up.y * throwDist), collision.transform.position.z);
            temp.isThrown = true;
        }
    }
}
