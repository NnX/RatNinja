﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private int healthValue = 100;
    [SerializeField] private ParticleSystem particleSystemLeft;
    [SerializeField] private ParticleSystem particleSystemRight;

    void Start() {
        healthBar.value = healthValue;
    }

    public void ApplyDamage(int damage) {
        healthValue -= damage;
        particleSystemLeft.Play();
        particleSystemRight.Play();

        if(healthValue <= 0) {
            healthValue = 0;

            GameController.Instance.ShowGameOverWindow();
        }

        healthBar.value = healthValue;

    }
}
