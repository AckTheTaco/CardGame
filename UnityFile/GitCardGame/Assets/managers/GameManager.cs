using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Broung in from Character SO
    public static int playerMaxHealth, playerCurrentHealth, Lvl1Req, Lvl2Req;

    // Updated as things change passively
    public static int  turnCount, deckListCount,discardCount, mansionCount, handCount;

    // Player modified info for min-to-min gameplay
    public static int Ammo, Gold, Buy, Explore, Action, Damage,  XP;

    [SerializeField] private  CharacterClass avatar;
    [Space]
    [SerializeField] private GameObject UI_Handler;

    void Start()
    {
        Buy = 1;
        Explore = 1;
        Action = 1;
    }


    void Update()
    {
        playerMaxHealth = avatar.Health;
        playerCurrentHealth = playerMaxHealth;
        Lvl1Req = avatar.Lvl1Req;
        Lvl2Req = avatar.Lvl2Req;
        deckListCount = CardHandler.DecCount;
        handCount = CardHandler.HandCount;
        discardCount = CardHandler.DiscardCount;
        mansionCount = CardHandler.MansionCount;
    }




}
