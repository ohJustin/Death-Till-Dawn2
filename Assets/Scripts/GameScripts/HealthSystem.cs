using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{

    //basic health system to keep track of enemies and player health
    private int currentHealth;
    private int maxHealth;

    public int Health {
        get {
            return currentHealth;
        }
        set {
            currentHealth = value;
        }
    }
    public int MaxHealth {
        get {
            return maxHealth;
        }
        set {
            maxHealth = value;
        }
    }

    public HealthSystem(int health, int max) {
        currentHealth = health;
        maxHealth = max;
    }

    public void TakeDmg(int dmg) {
        if (currentHealth > 0) {
            currentHealth -= dmg;
        }
        if (currentHealth < 0) {
            currentHealth = 0;
        }
    }

    public void Heal(int amount) {
        if (currentHealth < maxHealth) {
            currentHealth += amount;
        }
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
    }

}
