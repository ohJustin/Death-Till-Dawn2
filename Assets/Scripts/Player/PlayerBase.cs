using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBase : MonoBehaviour
{
    [SerializeField]
    protected int maxHealth = 10;
    public HealthSystem playerHealth;

    private GameObject playerHealthBar;

    void Start() {
        playerHealth = new HealthSystem(maxHealth, maxHealth);
        playerHealthBar = GameObject.Find("PlayerHealthBar");
        playerHealthBar.GetComponentInChildren<HealthBar>().SetMaxHealth(maxHealth);
        playerHealthBar.GetComponentInChildren<HealthBar>().SetCurrHealth(maxHealth);
    }

    


     private void OnTriggerEnter2D(Collider2D collision){
        if(collision.GetComponent<EnemyMovement>()){ 
            //We need to add tethering mechanisms to each zombie type, so that damage is specific.
            int dmg = 1;
            TakeDmg(dmg);
        }
    }
    public void TakeDmg(int dmg) {
            playerHealth.TakeDmg(dmg);
            playerHealthBar.GetComponentInChildren<HealthBar>().SetCurrHealth(playerHealth.Health);
            if (playerHealth.Health == 0) {
                SceneManager.LoadScene(2);
            }
        }
}
