using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    //started a base class for enemies that we can use to create future ones with the health system

    [SerializeField]
    protected int maxHealth = 3;
    public HealthSystem enemyHealth;
    public HealthBar enemyHealthBar;

    public void TakeDmg(int dmg) {
        enemyHealth.TakeDmg(dmg);
        enemyHealthBar.SetCurrHealth(enemyHealth.Health);
    }


    // Start is called before the first frame update
    virtual protected void Start()
    {
        enemyHealth = new HealthSystem(maxHealth, maxHealth);
        enemyHealthBar = gameObject.GetComponentInChildren<HealthBar>();
        enemyHealthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
