using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private int healthValue = 100;

    void Start() {
        healthBar.value = healthValue;
    }

    public void ApplyDamage(int damage) {
        healthValue -= damage;

        if(healthValue <= 0) {
            healthValue = 0;

            GameController.Instance.ShowGameOverWindow();
        }

        healthBar.value = healthValue;

    }
}
