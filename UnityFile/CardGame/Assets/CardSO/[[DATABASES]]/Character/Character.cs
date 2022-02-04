using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Character", menuName = "Character")]

public class Character : ScriptableObject
{
    public string charName;

    public int charMaxHealth;
    public int charCurrentHealth;
    
    public int startingLvl = 1;

    public int currentKills;
    
    public int charLvl1Req;

    public int charLvl2Req;

    public int charCurrentLvl;




}
