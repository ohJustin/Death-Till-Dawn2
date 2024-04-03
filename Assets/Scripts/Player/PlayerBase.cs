using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void TakeDmg(int dmg) {
        playerHealth.TakeDmg(dmg);
        playerHealthBar.GetComponentInChildren<HealthBar>().SetCurrHealth(playerHealth.Health);
    }
}
