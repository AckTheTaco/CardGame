using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerKills : MonoBehaviour
{

    
    public Character character; // calling charater class

    public int totalKills;
    
    public int playerCurrentLvl;
    public TMP_Text currentLevelText;
    // public int lvl1Req = 5; // needs to reference player card info
    
    public int lvl1Req;
    
    public int lvl2Req; 



    
    public TMP_Text currentKillsText;
   
    public TMP_Text killsReqText;

    public LevelBarGraphic statusBar; // reference the code made to adjust the bar fill

    void Start()
    {
        //character.charCurrentHealth = character.charMaxHealth;


        lvl1Req = character.charLvl1Req;
        lvl2Req = character.charLvl2Req;

        currentLevelText.text = character.startingLvl.ToString();
        currentKillsText.text = character.currentKills.ToString();
        killsReqText.text = character.charLvl1Req.ToString();

        statusBar.SetLVLGoal(lvl1Req);



        //Debug.Log(character.charName);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
            PlayerKilledSomething(1);
    }

    public void PlayerKilledSomething(int xp)
    {
        totalKills += xp;
        
        if (totalKills >= lvl1Req) // did you reach teh kills to become level 1?
        {            
            Debug.Log("Total kills: " + totalKills);

            playerCurrentLvl = 1;
            currentLevelText.text = playerCurrentLvl.ToString();
            killsReqText.text = lvl2Req.ToString();
            Debug.Log("Player is level " + playerCurrentLvl);
            
            statusBar.SetCurrentKills(totalKills); // uses "total kills" to 
            statusBar.SetLVLGoal(lvl2Req);
        }
        if (totalKills >= lvl2Req)
        {  
            Debug.Log("Total kills: " + totalKills);

            playerCurrentLvl = 2;
            currentLevelText.text = playerCurrentLvl.ToString();  // change badge to LVL number
            currentKillsText.text = totalKills.ToString();
            Debug.Log("Player is level " + playerCurrentLvl);

            statusBar.SetCurrentKills(totalKills);
        }  
        else
        {
            currentKillsText.text = totalKills.ToString();
            statusBar.SetCurrentKills(totalKills);
            Debug.Log("Total kills: " + totalKills);
        }
        
        if (totalKills >= lvl2Req)
        {
            killsReqText.text = "Max Level";
            // change font to MAX LEVEL
        }

        
    }
}
