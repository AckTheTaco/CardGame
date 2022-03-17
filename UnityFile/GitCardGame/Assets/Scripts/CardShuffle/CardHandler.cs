using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardHandler : MonoBehaviour
{
    public static CardHandler instance;

    


    public EmptyPlayerDeck StartingInventory;
    public MansionDatabaseClass MansionData;
    [Space]

    [SerializeField] public ResourceCollectionBase _scenario1;

    public static ResourceCollectionBase Scenario;
    [Space]
    [SerializeField] private List<CardClass> testList;
    [Space]

   /*
   *Make a dictionary here for reasons
   * public Dictionary<string, List<CompleteCard>> = new Dictionary<string, List<CompleteCard>>();
   */

    public Dictionary<string, List<CompleteCard>> listDictionary = new Dictionary<string, List<CompleteCard>>();
   
    [SerializeField]public List<CompleteCard> MansionDeck;
    public static List<CompleteCard> staticMansionDeck;

    [Space]
    [Header("Players Cards")]
    
    [SerializeField]public  List<CompleteCard> PlayerDeck;
    [SerializeField]public  List<CompleteCard> PlayerHand = new List<CompleteCard>();
    [SerializeField]public  List<CompleteCard> PlayerDiscard = new List<CompleteCard>();

    [Space]
    [Header("Player Area")]
    [SerializeField]public List<CompleteCard> ActiveWeapons = new List<CompleteCard>();

    [SerializeField]public List<CompleteCard> ActiveItems = new List<CompleteCard>();

    [SerializeField]public List<CompleteCard> ActiveActions = new List<CompleteCard>();

    
    [SerializeField]public  static List<CompleteCard> staticPlayerDiscard;
    public static int MansionCount;
    public static int HandCount;
    public static int DiscardCount;
    public static int DecCount;
    [Space]
    [Header("Resource Area")]
    #region ResourcePile Lists
    
    public  List<CompleteCard> pile1 = new List<CompleteCard>();
    public  List<CompleteCard> pile2 = new List<CompleteCard>();
    public   List<CompleteCard> pile3 = new List<CompleteCard>();
    public   List<CompleteCard> pile4 = new List<CompleteCard>();
    public   List<CompleteCard> pile5 = new List<CompleteCard>();
    public   List<CompleteCard> pile6 = new List<CompleteCard>();
    public   List<CompleteCard> pile7 = new List<CompleteCard>();
    public   List<CompleteCard> pile8 = new List<CompleteCard>();
    public   List<CompleteCard> pile9 = new List<CompleteCard>();
    public   List<CompleteCard> pile10 = new List<CompleteCard>();
    public   List<CompleteCard> pile11 = new List<CompleteCard>();
    public  List<CompleteCard> pile12 = new List<CompleteCard>();
    public   List<CompleteCard> pile13 = new List<CompleteCard>();
    public   List<CompleteCard> pile14 = new List<CompleteCard>();
    public   List<CompleteCard> pile15 = new List<CompleteCard>();
    public   List<CompleteCard> pile16 = new List<CompleteCard>();
    public   List<CompleteCard> pile17 = new List<CompleteCard>();
    public  List<CompleteCard> pile18 = new List<CompleteCard>();
    #endregion

    [Space]
    [Header("Defeated Zombies Area")]
    public List<CompleteCard> ZombiesDefeated = new List<CompleteCard>();

   

    

  void Awake()
   {
       #region Now an Instance
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        #endregion

        listDictionary.Add("Mansion", MansionDeck);
        listDictionary.Add("PlayerHandHolder", PlayerHand);
        listDictionary.Add("PlayerDeck", PlayerDeck);
        listDictionary.Add("WeaponHolder", ActiveWeapons);
        listDictionary.Add("ActionHolder", ActiveActions);
        listDictionary.Add("ItemHolder", ActiveItems);        
        listDictionary.Add("KilledZombies", ZombiesDefeated);
        listDictionary.Add("PlayerDiscard", PlayerDiscard);

        
        

        
    }
    void Start()
    {
        
        listDictionary["PlayerDeck"] = new List<CompleteCard>(StartingInventory.aDeck);
        listDictionary["MansionDeck"] = new List<CompleteCard>(GameManager.instance.chosenMansion.thisMansion);
        

        staticMansionDeck = new List<CompleteCard>(MansionDeck);
        Scenario = ScriptableObject.Instantiate(GameManager.instance.chosenScenario);

        for (int i = 0; i < Scenario.thisCollection.Count; i++)
        {
            
           // print($"I have a pile of {pileOfCards.thesePiles.Count}x {pileOfCards.name}'s ");
            MakePileIntoLists(Scenario.thisCollection[i], i);
        }

        void MakePileIntoLists(ResourcePileBase pile, int pileNumber)
        {
            
            string pileName =  "pile"+ (pileNumber+1).ToString();

            if(!listDictionary.ContainsKey(pileName))
            {
                listDictionary.Add(pileName, pile.thesePiles);
                listDictionary[pileName] = new List<CompleteCard>(pile.thesePiles); 
            }
            else
            {
                listDictionary[pileName] = new List<CompleteCard>(pile.thesePiles);
            }

        }

        var pilesCount = Scenario.thisCollection.Count;

        for (int i = 0; i < pilesCount; i++)
        {
            string pile = "pile" + (i+1).ToString();
            UiHandler.instance.CreateCardUI(CardHandler.ScenarioList().thisCollection[i].thesePiles[0], GameObject.Find(pile).transform, pile);
        }

        ShuffleAllDecksAtStart();

        DrawACard(5, listDictionary["PlayerDeck"], listDictionary["PlayerHandHolder"]);

      

        //Debug.Log(Scenario);
        
        
        

        //DrawACard(2)

       
    }
    void Update()
    {
        #region Visualize Dictionary Lists as they change

        MansionDeck = listDictionary["MansionDeck"];

        pile1 = new List<CompleteCard>(listDictionary["pile1"]);
        pile2 = new List<CompleteCard>(listDictionary["pile2"]);
        pile3 = new List<CompleteCard>(listDictionary["pile3"]);
        pile4 = new List<CompleteCard>(listDictionary["pile4"]);
        pile5 = new List<CompleteCard>(listDictionary["pile5"]);
        pile6 = new List<CompleteCard>(listDictionary["pile6"]);
        pile7 = new List<CompleteCard>(listDictionary["pile7"]);
        pile8 = new List<CompleteCard>(listDictionary["pile8"]);
        pile9 = new List<CompleteCard>(listDictionary["pile9"]);
        pile10 = new List<CompleteCard>(listDictionary["pile10"]);
        pile11 = new List<CompleteCard>(listDictionary["pile11"]);
        pile12 = new List<CompleteCard>(listDictionary["pile12"]);
        pile13 = new List<CompleteCard>(listDictionary["pile13"]);
        pile14 = new List<CompleteCard>(listDictionary["pile14"]);
        pile15 = new List<CompleteCard>(listDictionary["pile15"]);
        pile16 = new List<CompleteCard>(listDictionary["pile16"]);
        pile17 = new List<CompleteCard>(listDictionary["pile17"]);
        pile18 = new List<CompleteCard>(listDictionary["pile18"]);

        PlayerDeck = new List<CompleteCard>(listDictionary["PlayerDeck"]);
        PlayerHand = new List<CompleteCard>(listDictionary["PlayerHandHolder"]);
        PlayerDiscard = new List<CompleteCard>(listDictionary["PlayerDiscard"]);

        ActiveItems = new List<CompleteCard>(listDictionary["ItemHolder"]);
        ActiveWeapons = new List<CompleteCard>(listDictionary["WeaponHolder"]);
        ActiveActions = new List<CompleteCard>(listDictionary["ActionHolder"]);

        #endregion

        staticPlayerDiscard = new List<CompleteCard>(listDictionary["PlayerDiscard"]);
        MansionCount = listDictionary["MansionDeck"].Count;
        HandCount = listDictionary["PlayerHandHolder"].Count;
        DiscardCount = listDictionary["PlayerDiscard"].Count;
        DecCount = listDictionary["PlayerDeck"].Count;
    }
   
    public void ShuffleAllDecksAtStart()
    {
        Dictionary<string, List<CompleteCard>>.KeyCollection keys = listDictionary.Keys;
        foreach(string val in keys)
        {
            Shuffler.ShuffleDeck(listDictionary[val]);
            //print($"I shuffled Keys: {val}");
        }
    }
   
    public void DrawACard(int n, List<CompleteCard> fromDeck, List<CompleteCard> toDeck )
    {
        if (n > fromDeck.Count)
        {
            Debug.Log("Cannot draw more cards then are in the deck");
            return;
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                toDeck.Add(fromDeck[0]);
                UiHandler.instance.CreateCardUI(fromDeck[0], GameObject.Find("PlayerHandHolder").transform, "PlayerHandHolder");
                fromDeck.RemoveAt(0);
            }
        }
    }


    public void ResetPlayerDeck()
    {
       if( listDictionary["PlayerDeck"].Count < 5)
       {
           Shuffler.ShuffleDeck(listDictionary["PlayerDiscard"]);
           listDictionary["PlayerDeck"].Clear();
           listDictionary["PlayerDeck"] = new List<CompleteCard>(listDictionary["PlayerDiscard"]);
           listDictionary["PlayerDiscard"].Clear();
       }
    }

    public static ResourceCollectionBase ScenarioList()
    {
        return Scenario;
    }
    public void PlayerTurnEnd()
    {
        
        ClearExploreArea();
        
        SendToDiscard("WeaponHolder");
        SendToDiscard("ItemHolder");
        SendToDiscard("ActionHolder");
        SendToDiscard("PlayerHandHolder");


        listDictionary["WeaponHolder"].Clear();
        listDictionary["ItemHolder"].Clear();
        listDictionary["ActionHolder"].Clear();


        GameManager.instance.Buy = 1;
        GameManager.instance.Explore = 1;
        GameManager.instance.Action = 1;
        GameManager.instance.Gold = 0;
        GameManager.instance.Ammo = 0;
        GameManager.instance.PlayerDamage = 0;
        GameManager.instance.turnCount++;
    }

    public void PlayerDieReset()
    {
       listDictionary["PlayerDiscard"].AddRange(listDictionary["PlayerHandHolder"]);
       listDictionary["PlayerDiscard"].AddRange(listDictionary["PlayerDeck"]);
       listDictionary["PlayerHandHolder"].Clear();
       listDictionary["PlayerDeck"].Clear();
       Shuffler.ShuffleDeck(listDictionary["PlayerDiscard"]);
    


        
    }

    public void BuyACard()
    {
        
        Debug.Log($"You can buy {GameManager.instance.Buy} card(s)");
    }

    void SendToDiscard(string locationName)
    {
        

        if (locationName == "PlayerHandHolder")
        {
            foreach (Transform child in GameObject.Find(locationName).transform)
            {
                Destroy(child.gameObject);
            }
            int PHC = listDictionary[locationName].Count;

            for (int i = 0; i < PHC; i++)
            {
                listDictionary["PlayerDiscard"].Add(listDictionary[locationName][0]);
                listDictionary[locationName].RemoveAt(0);
                
            }

            if (listDictionary["PlayerDeck"].Count <= 5)
            {
                listDictionary[locationName].Clear();
                

                listDictionary[locationName] = new List<CompleteCard>(listDictionary["PlayerDeck"]);
                int i = 0;
                foreach (CompleteCard card in listDictionary[locationName]) // TODO this could be a for loop
                {
                    
                UiHandler.instance.CreateCardUI(listDictionary[locationName][i], GameObject.Find(locationName).transform, locationName);
                i++;
                }
                i = 0;

                listDictionary["PlayerDeck"].Clear();

                if ( listDictionary[locationName].Count < 5)
                {
                ResetPlayerDeck();
                DrawACard((5-listDictionary[locationName].Count), listDictionary["PlayerDeck"], listDictionary[locationName]);
                }

            }
            else
            {
                DrawACard(5,listDictionary["PlayerDeck"],listDictionary[locationName]);
            }
        }
        else
        {
            foreach (Transform child in GameObject.Find(locationName).transform)
            {
                Destroy(child.gameObject);
            }
            for (int i = 0; i < listDictionary[locationName].Count; i++)
            {
                listDictionary["PlayerDiscard"].Add(listDictionary[locationName][i]);
            }
        }
    }

    void ClearExploreArea()
    {
        foreach (Transform child in GameObject.Find("ExploreArea").transform)
        {
            Destroy(child.gameObject);
        }
    }
}
