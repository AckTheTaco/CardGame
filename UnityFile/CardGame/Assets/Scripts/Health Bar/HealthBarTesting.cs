using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarTesting : MonoBehaviour
{
    public Character character;
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;
    public GameObject respawnButton;
    public GameObject goScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = character.charMaxHealth;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        respawnButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TakeDamage(20);
        if (Input.GetKeyDown(KeyCode.H))
            GetHealed(15);
    }

    public void TakeDamage(int damage)
    {
        
        
        if ((currentHealth - damage) <= 0)
        {
            currentHealth = 0;
            UpdateHealthBar();

            Debug.Log("you have died!");
            
            if ((maxHealth - 20) > 0 && currentHealth == 0)
            {
                Debug.Log("you done goofed" + maxHealth + " Max Health");
                respawnButton.SetActive(true); // make respawn button active
            }
            else 
            {
                GameOver();                
                respawnButton.SetActive(false);
            }
        }
        else
        {
        currentHealth -= damage;
        respawnButton.SetActive(false);
        UpdateHealthBar();
        }
    }

    public void GetHealed(int heal)
    {
        if ((heal + currentHealth) >= maxHealth)
        {
            currentHealth = maxHealth;
            UpdateHealthBar();
        } 
        else
        {
            currentHealth += heal;
            UpdateHealthBar();

        }
    }

    

    public void Respawn()
    {
        maxHealth -= 20;
        currentHealth = maxHealth;
        healthBar.RespawnUpdate(maxHealth, currentHealth);
        respawnButton.SetActive(false);
    }

    void GameOver()
    {
         goScreen.SetActive(true);
         Debug.Log("GAME OVER!! bro bro ");
    }

    public void UpdateHealthBar()
    {
        healthBar.currentHealthText.text = currentHealth.ToString();
        healthBar.SetHealth(currentHealth);
    }

    public void AddMaxHealth(int maxAdded)
    {
        maxHealth += maxAdded;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.maxHealthText.text = maxHealth.ToString();
        UpdateHealthBar();
    }

    public void SubtractMaxHealth(int maxLost)
    {
        maxHealth -= maxLost;
       
       if (maxHealth <= 0)
       {
           GameOver();
       }
       else
       {
            Debug.Log("Max Health : " + maxHealth);
            Debug.Log("current Health : " + currentHealth);
            
            
            if (currentHealth > maxHealth)
            {
                
                currentHealth = maxHealth;
                
                healthBar.SetMaxHealth(maxHealth);
                healthBar.maxHealthText.text = maxHealth.ToString();
                UpdateHealthBar();
                healthBar.currentHealthText.text = maxHealth.ToString();
            }
            else
            {
                healthBar.SetMaxHealth(maxHealth);
                healthBar.maxHealthText.text = maxHealth.ToString();
                UpdateHealthBar();
            }
       }
    }
}
