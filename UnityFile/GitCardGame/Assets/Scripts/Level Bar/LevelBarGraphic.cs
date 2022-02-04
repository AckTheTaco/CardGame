using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LevelBarGraphic : MonoBehaviour
{
    public Slider slider;

    public Image fill;


   // public PlayerKills player;
    

 
    public void SetLVLGoal(int killsNeeded)
    {
        slider.value = 0; // sets the current value to requirement - requirement

        slider.maxValue = killsNeeded; // assigns the number needed to become level 1

       
        
        Debug.Log("Kills Needed: " + killsNeeded);
    }

    public void SetCurrentKills(int currentKills)
    {
        slider.value = currentKills; // sets the slider to the number of kills player currently has
    }   



    public void NextLevel(int playerCurrentLevel, int playerNextLevelReq)
    {
        if (playerCurrentLevel == 1)
        { 
            slider.value = 0;
            slider.maxValue = playerNextLevelReq;

        }

    }
}
