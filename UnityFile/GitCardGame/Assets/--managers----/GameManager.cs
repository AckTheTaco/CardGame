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
    public int Ammo, Gold, Buy, Explore, Action, PlayerDamage,  XP;

    [Space]
    [SerializeField] public CharacterClass avatar;
    [SerializeField] public MansionDatabaseClass chosenMansion;
    [SerializeField] public ResourceCollectionBase chosenScenario;
    [Space]
    [SerializeField] public GameObject DiscardWindow;

    [SerializeField] public GameObject GameOverScreen;

    [Space]
    [SerializeField] public List<CharacterClass> _listOfCharacters;
    [SerializeField] public List<ResourceCollectionBase> ListOfScenarios;
    


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
        //print("I have a character, scenario. mansion");
            // avatar = Selection.instance.ListOfCharacters[PlayerPrefs.GetInt("Character", 0)];
            // chosenScenario = Selection.instance.ListOfScenarios[PlayerPrefs.GetInt("Scenario", 0)];
            // chosenMansion = Selection.instance.ListOfMansions[PlayerPrefs.GetInt("Mansion", 0)];

    }

    void Start()
    {
        
        Buy = 1;
        Explore = 1;
        Action = 1;

        // if(Selection.instance != null)
        // {}
            

            
            
        


        
        // print(avatar.name);
        // print(chosenMansion.name);
        // print(chosenScenario.name);

       
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
