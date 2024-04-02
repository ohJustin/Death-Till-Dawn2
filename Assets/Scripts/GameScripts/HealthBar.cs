using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{


    //basic health bar scrpit to control the new health bars

    private Slider healthSlider;

    public void SetMaxHealth(int maxHealth) {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void SetCurrHealth(int health) {
        healthSlider.value = health;
    }

    void Start() {
        healthSlider = GetComponent<Slider>();
    }
}
