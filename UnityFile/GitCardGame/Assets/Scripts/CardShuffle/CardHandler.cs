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

   /*
   *Make a dictionary here for reasons
   * public Dictionary<string, List<CompleteCard>> = new Dictionary<string, List<CompleteCard>>();
   */
   
    [SerializeField]public List<CompleteCard> MansionDeck;
    public static List<CompleteCard> staticMansionDeck;

    [SerializeField]public  List<CompleteCard> PlayerDeck;
    [SerializeField]public  List<CompleteCard> PlayerHand = new List<CompleteCard>();
    [SerializeField]public  List<CompleteCard> PlayerDiscard = new List<CompleteCard>();

    [SerializeField]public List<CompleteCard> ActiveWeapons = new List<CompleteCard>();

    [SerializeField]public List<CompleteCard> ActiveItems = new List<CompleteCard>();

    [SerializeField]public List<CompleteCard> ActiveActions = new List<CompleteCard>();
    [SerializeField]public  static List<CompleteCard> staticPlayerDiscard;
    public static int MansionCount;
    public static int HandCount;
    public static int DiscardCount;
    public static int DecCount;

    #region ResourcePile Lists
    
    public  static List<CompleteCard> pile1 = new List<CompleteCard>();
    public  static List<CompleteCard> pile2 = new List<CompleteCard>();
    public  static List<CompleteCard> pile3 = new List<CompleteCard>();
    public  static List<CompleteCard> pile4 = new List<CompleteCard>();
    public  static List<CompleteCard> pile5 = new List<CompleteCard>();
    public  static List<CompleteCard> pile6 = new List<CompleteCard>();
    public  static List<CompleteCard> pile7 = new List<CompleteCard>();
    public  static List<CompleteCard> pile8 = new List<CompleteCard>();
    public  static List<CompleteCard> pile9 = new List<CompleteCard>();
    public  static List<CompleteCard> pile10 = new List<CompleteCard>();
    public  static List<CompleteCard> pile11 = new List<CompleteCard>();
    public static List<CompleteCard> pile12 = new List<CompleteCard>();
    public  static List<CompleteCard> pile13 = new List<CompleteCard>();
    public  static List<CompleteCard> pile14 = new List<CompleteCard>();
    public  static List<CompleteCard> pile15 = new List<CompleteCard>();
    public  static List<CompleteCard> pile16 = new List<CompleteCard>();
    public  static List<CompleteCard> pile17 = new List<CompleteCard>();
    public  List<CompleteCard> pile18 = new List<CompleteCard>();
    #endregion

   

    

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

        
    }
    void Start()
    {
        //DeckTest = new List<CompleteCard>();
        PlayerDeck = new List<CompleteCard>(StartingInventory.aDeck);
        MansionDeck = new List<CompleteCard>(GameManager.instance.chosenMansion.thisMansion);
        print(GameManager.instance.chosenMansion.name);

        staticMansionDeck = new List<CompleteCard>(MansionDeck);
        Scenario = ScriptableObject.Instantiate(GameManager.instance.chosenScenario);
        

        #region Resource Area Pile Assignment
        pile1 = Scenario.thisCollection[0].thesePiles;
        pile2 = Scenario.thisCollection[1].thesePiles;
        pile3 = Scenario.thisCollection[2].thesePiles;
        pile4 = Scenario.thisCollection[3].thesePiles;
        pile5 = Scenario.thisCollection[4].thesePiles;
        pile6 = Scenario.thisCollection[5].thesePiles;
        pile7 = Scenario.thisCollection[6].thesePiles;
        pile8 = Scenario.thisCollection[7].thesePiles;
        pile9 = Scenario.thisCollection[8].thesePiles;
        pile10 = Scenario.thisCollection[9].thesePiles;
        pile11 = Scenario.thisCollection[10].thesePiles;
        pile12 = Scenario.thisCollection[11].thesePiles;
        pile13 = Scenario.thisCollection[12].thesePiles;
        pile14 = Scenario.thisCollection[13].thesePiles;
        pile15 = Scenario.thisCollection[14].thesePiles;
        pile16 = Scenario.thisCollection[15].thesePiles;
        pile17 = Scenario.thisCollection[16].thesePiles;
        pile18 = Scenario.thisCollection[17].thesePiles;
        #endregion

        ShuffleAllDecksAtStart();

        DrawACard(5, PlayerDeck, PlayerHand);

      

        Debug.Log(Scenario);
        
        
   
    
    }
    void Update()
    {
        staticPlayerDiscard = new List<CompleteCard>(PlayerDiscard);
        MansionCount = MansionDeck.Count;
        HandCount = PlayerHand.Count;
        DiscardCount = PlayerDiscard.Count;
        DecCount = PlayerDeck.Count;
    }
   
    public void ShuffleAllDecksAtStart()
    {
        AudioManager.instance.PlaySound("Shuffle");
        Shuffler.ShuffleDeck(PlayerDeck);
        Shuffler.ShuffleDeck(MansionDeck);
        Shuffler.ShuffleDeck(staticMansionDeck);
        Shuffler.ShuffleDeck(pile1);
        Shuffler.ShuffleDeck(pile2);
        Shuffler.ShuffleDeck(pile3);
        Shuffler.ShuffleDeck(pile4);
        Shuffler.ShuffleDeck(pile5);
        Shuffler.ShuffleDeck(pile6);
        Shuffler.ShuffleDeck(pile7);
        Shuffler.ShuffleDeck(pile8);
        Shuffler.ShuffleDeck(pile9);
        Shuffler.ShuffleDeck(pile10);
        Shuffler.ShuffleDeck(pile11);
        Shuffler.ShuffleDeck(pile12);
        Shuffler.ShuffleDeck(pile13);
        Shuffler.ShuffleDeck(pile14);
        Shuffler.ShuffleDeck(pile15);
        Shuffler.ShuffleDeck(pile16);
        Shuffler.ShuffleDeck(pile17);
        Shuffler.ShuffleDeck(pile18);
        

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
                UiHandler.instance.CreateCardUI(fromDeck[0], GameObject.Find("PlayerHandHolder").transform);
                fromDeck.RemoveAt(0);
            }
        }
    }


    public void ResetPlayerDeck()
    {
       if( PlayerDeck.Count < 5)
       {
           Shuffler.ShuffleDeck(PlayerDiscard);
           PlayerDeck.Clear();
           PlayerDeck = new List<CompleteCard>(PlayerDiscard);
           PlayerDiscard.Clear();
       }
    }


    public void PlayerTurnEnd()
    {
        foreach (Transform child in GameObject.Find("PlayerHandHolder").transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in GameObject.Find("WeaponHolder").transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < ActiveWeapons.Count; i++)
        {
            PlayerDiscard.Add(ActiveWeapons[0]);
        }

        foreach (Transform child in GameObject.Find("ItemHolder").transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < ActiveItems.Count; i++)
        {
            PlayerDiscard.Add(ActiveItems[0]);
        }

        foreach (Transform child in GameObject.Find("ActionHolder").transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < ActiveActions.Count; i++)
        {
            PlayerDiscard.Add(ActiveActions[0]);
        }


        ActiveWeapons.Clear();
        ActiveItems.Clear();
        ActiveActions.Clear();



        int PHC = PlayerHand.Count;

        for (int i = 0; i < PHC; i++)
        {
            PlayerDiscard.Add(PlayerHand[0]);
            PlayerHand.RemoveAt(0);
            
        }

        if (PlayerDeck.Count <= 5)
        {
            PlayerHand.Clear();
            

            PlayerHand = new List<CompleteCard>(PlayerDeck);
            int i = 0;
            foreach (CompleteCard card in PlayerHand)
            {
                
               UiHandler.instance.CreateCardUI(PlayerHand[i], GameObject.Find("PlayerHandHolder").transform);
               i++;
            }
            i = 0;

            PlayerDeck.Clear();

            if ( PlayerHand.Count < 5)
            {
               ResetPlayerDeck();
               DrawACard((5-PlayerHand.Count), PlayerDeck, PlayerHand);
            }

        }
        else
        {
            DrawACard(5,PlayerDeck,PlayerHand);
        }
        GameManager.instance.turnCount++;
    }

    public void PlayerDieReset()
    {
       PlayerDiscard.AddRange(PlayerHand);
       PlayerDiscard.AddRange(PlayerDeck);
       PlayerHand.Clear();
       PlayerDeck.Clear();
       Shuffler.ShuffleDeck(PlayerDiscard);
    


        
    }

    public void BuyACard()
    {
        
        Debug.Log($"You can buy {GameManager.instance.Buy} card(s)");
    }

    public void MoveCardInList(CompleteCard thisCard, List<CompleteCard> currentList)
    {
        thisCard.CurrentListPosition = currentList;
    }



}
