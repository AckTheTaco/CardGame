using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{

    public Character character;
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;

    public GameObject respawnButton;
    
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = character.charMaxHealth;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        respawnButton.SetActive(false);
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TakeDamage(20);
        
    }
    void TakeDamage(int damage)
    {
        
        
        if ((currentHealth - damage) <= 0)
        {
            currentHealth = 0;
            UpdateHealthBar();

            Debug.Log("you have died!");
            
            if (maxHealth > 0 && (maxHealth - 20) > 0)
            {
                Debug.Log("you done goofed" + maxHealth + " Max Health");
                respawnButton.SetActive(true); // make respawn button active
            }
            else 
            {
                Debug.Log("GAME OVER!! bro bro " + currentHealth);
                respawnButton.SetActive(false);
            }
        }
        else
        {
        currentHealth -= damage;
        UpdateHealthBar();
        }
    }

    public void UpdateHealthBar()
    {
        healthBar.currentHealthText.text = currentHealth.ToString();
        healthBar.SetHealth(currentHealth);
    }
}
