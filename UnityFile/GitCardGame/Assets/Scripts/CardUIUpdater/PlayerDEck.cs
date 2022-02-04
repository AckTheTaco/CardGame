using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDEck : MonoBehaviour
{

    public List<ACardClass> container = new List<ACardClass>();
    public static int deckSize;
    public List<ACardClass> playerDeck = new List<ACardClass>();
    public static List<ACardClass> staticPlayerDeck = new List<ACardClass>();
    private int x;

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    [Space]
    public GameObject CardToHand;

    public GameObject MansionToExplore;
    public GameObject DeckToHand;
    [Space]
    public GameObject[] Clones;
    public GameObject Hand;

    

    void Start()
    {
        x = 0;
        deckSize = 40;
        

        for (int i = 0; i < 40; i++)      
        {
            x = Random.Range(1, 5);
            playerDeck.Add(CardDatabase.cardClassList[x]);


        }
       // StartCoroutine(StartGame());

    }

    void Update()
    {
        // staticPlayerDeck = playerDeck;

        // if (deckSize < 30)        
        //     cardInDeck1.SetActive(false);
        // if (deckSize < 20)        
        //     cardInDeck2.SetActive(false);
        // if (deckSize < 10)        
        //     cardInDeck3.SetActive(false);
        // if (deckSize < 1)        
        // {
        //     cardInDeck4.SetActive(false);
        // }


        // if (TurnSystem.startTurn == true)
        // {
        //     DrawOneCard(1);
        // }
    }

    public void Shuffle()
    {
        
        for (int i = 0; i < deckSize; i++)
        {
            container[0] = playerDeck[i];
            int randomIndex = Random.Range(i, deckSize);
            playerDeck[i] = playerDeck[randomIndex];
            playerDeck[randomIndex] = container[0];

        }
    }


    //
    // Find a Better Delay method
    //
    //
    // IEnumerator StartGame()
    // {
    //     for ( int i = 0; i <= 39; i++)
    //     {
    //         yield return new WaitForSeconds(1);
    //         Instantiate(CardToHand, transform.position, transform.rotation);
    //     }
    // }
    
    


    public void DoTheExplore()
    {
        Instantiate(MansionToExplore, transform.position, transform.rotation);
    }

    public void DrawTheCardToTheHand()
    {
        Instantiate(DeckToHand, transform.position, transform.rotation);
    }

    public void DrawOneCard(int x)
    {
        for (int i =0; i < x; i++)
        {
            Instantiate(DeckToHand, transform.position, transform.rotation);
        }
    }
}
