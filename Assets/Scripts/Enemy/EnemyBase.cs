using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    //started a base class for enemies that we can use to create future ones with the health system

    public GameObject player;
    [SerializeField]
    protected int maxHealth = 3;
    public HealthSystem enemyHealth;
    
    public int dmg = 5;
    public HealthBar enemyHealthBar;

    public GameManager gm;

    public bool dead = false;

    public void TakeDmg(int dmg) {
        enemyHealthBar.GetComponentInParent<Canvas>().enabled = true;
        enemyHealth.TakeDmg(dmg);
        enemyHealthBar.SetCurrHealth(enemyHealth.Health);
    }


   

    // Start is called before the first frame update
    virtual protected void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyHealth = new HealthSystem(maxHealth, maxHealth);
        enemyHealthBar = gameObject.GetComponentInChildren<HealthBar>();
        enemyHealthBar.SetMaxHealth(maxHealth);
        enemyHealthBar.GetComponentInParent<Canvas>().enabled = false;
    }

    virtual public void IncreaseDiff() {
        gm.ScoreCounter += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
