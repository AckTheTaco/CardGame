using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //using UI\
using TMPro;

public class HealthBar : MonoBehaviour
{

    public Character character;

    public TMP_Text maxHealthText;
    public TMP_Text currentHealthText;

     public Slider slider; // slider object needs to be assigned in the unity inspector

    public Gradient gradient; // make gradient in Inspector

    public Image fill;  // assigned in the inspector so the gradient knows what to modify

    //public float lerpSpeed;
  

   
    void Start()
    {
        
       maxHealthText.text = character.charMaxHealth.ToString();
       currentHealthText.text = character.charCurrentHealth.ToString();


    }

    void Update()
    {
        //lerpSpeed = 2f * Time.deltaTime;    
    }

   
    public void SetMaxHealth(int health)  // public to call from other scripts
    {
        slider.maxValue = health;
        slider.value = health;
        // maxHealthText.text = character.charMaxHealth.ToString();
       
    

        fill.color = gradient.Evaluate(1f);  // set the fill image color to the 100% (1f) value at start
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        
        
        

        fill.color = gradient.Evaluate(slider.normalizedValue); //normalized value chang3s values to 0 - 1 instead as percents of completely filed

    }
   public void RespawnUpdate(int max, int curr)
   {
       SetMaxHealth(max);
       SetHealth(curr);
       maxHealthText.text = max.ToString();
       currentHealthText.text = curr.ToString();

   }
}

//HealthBar.fillAmount = Mathf.Lerp(healthBar.fill, currentHealth / maxhealth, lerpSpeed)
// fill.fillAmount = Mathf.Lerp(fill.fillAmount, character.charCurrentHealth / character.charMaxHealth, lerpSpeed);