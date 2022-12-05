using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    float NoDamageTime = 0;
    float nextDamage = 1;

    public LevelManager gameLevelManager;

    public HealthBar healthBar;

    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.name == "Enemy")
        { 
            if(NoDamageTime <= 0)
            {
                currentHealth = currentHealth - 20;
                healthBar.SetHealth(currentHealth);
                NoDamageTime = nextDamage;
            }
            else
            {
                NoDamageTime -= 2 * Time.deltaTime;
            }
        }
        if (other.gameObject.name == "trap")
        {
            if (NoDamageTime <= 0)
            {
                currentHealth = currentHealth - 50;
                healthBar.SetHealth(currentHealth);
                NoDamageTime = nextDamage;
            }
            else
            {
                NoDamageTime -= 2 * Time.deltaTime;
            }
        }
    }
    
    void Update()
    {
        if (currentHealth <= 0)
        {
            gameLevelManager.Respawn();
            currentHealth = 100;
            healthBar.SetHealth(currentHealth);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
