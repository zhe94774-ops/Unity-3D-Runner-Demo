using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;
    public Healthbar healthbar;
    public GameObject damageEffect;

    private bool canTakeDamage = true; // 能不能受伤

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetmaxHealth(maxHealth);
    }

    public void TakeDamage(int amount)
    {
        if (!canTakeDamage) return;
        canTakeDamage = false; 

        Audiomanager.instance.PlaySfx(0);
        Instantiate(damageEffect, transform.position, Quaternion.identity);

        currentHealth -= amount;
        healthbar.SetHealth(currentHealth);


        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return; 
        }

        Invoke(nameof(ResetDamage), 1.0f);
    }

    private void ResetDamage()
    {
        canTakeDamage = true;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        healthbar.SetHealth(currentHealth);
    }
}