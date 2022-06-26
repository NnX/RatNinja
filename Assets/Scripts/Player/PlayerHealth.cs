using System;
using GameEnvironment;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private const int MaxHealth = 100;
    [SerializeField] private Slider healthBar;
    [SerializeField] private ParticleSystem particleSystemLeft;
    [SerializeField] private ParticleSystem particleSystemRight;

    private int _currentHealth;
    private void Start()
    {
        _currentHealth = MaxHealth;
        healthBar.value = _currentHealth;
    }

    public void Reset()
    {
        _currentHealth = MaxHealth;
        healthBar.value = MaxHealth;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        particleSystemLeft.Play();
        particleSystemRight.Play();

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            GameController.Instance.PauseGame();
            GameController.Instance.ShowGameOverWindow();
        }

        healthBar.value = _currentHealth;
    }
}