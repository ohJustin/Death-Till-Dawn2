using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerBase : MonoBehaviour
{
    [SerializeField]
    protected int maxHealth = 10;
    public HealthSystem playerHealth;

    private GameObject playerHealthBar;

    public UnityEvent OnDamaged;
    public bool isInvincible {get; set;}

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
        if(isInvincible){
            return;
        }


        playerHealth.TakeDmg(dmg);
        playerHealthBar.GetComponentInChildren<HealthBar>().SetCurrHealth(playerHealth.Health);
        if (playerHealth.Health == 0) {
            Invoke("DeathScreen", 2);
        }else{
            OnDamaged.Invoke();
        }
    }

    public void DeathScreen() {
        SceneManager.LoadScene(2);
    }
}
