using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Broung in from Character SO
    public int playerMaxHealth, playerCurrentHealth, Lvl1Req, Lvl2Req;

    

    // Updated as things change passively
    public int  turnCount, deckListCount,discardCount, mansionCount, handCount;

    // Player modified info for min-to-min gameplay
    public int Ammo, Gold, Buy, Explore, Action, Damage,  XP;

    [Space]
    [SerializeField] private  CharacterClass avatar;
    [Space]
    [SerializeField] public GameObject DiscardWindow;

    [SerializeField] public GameObject GameOverScreen;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }

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

    public void GameOver()
    {
        Instantiate(GameOverScreen, GameObject.Find("Canvas").transform);
    }

    

}
