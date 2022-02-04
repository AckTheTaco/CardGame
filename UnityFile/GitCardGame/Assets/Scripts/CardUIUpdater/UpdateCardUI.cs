using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpdateCardUI : MonoBehaviour
{

    //public CardClass thisCard;

    public List<ACardClass> DisplayCard = new List<ACardClass>();

    public int displayID;

    public int id;

    [Space]

    public string _cardName;
    public string _cardType;
    public string _cardID;
    public string _cardEdition;
    [Space]
    public TMP_Text cardNameText;
    public TMP_Text cardTypeText;
    public TMP_Text cardIDText;
    public TMP_Text cardEditionText;

    public bool cardBack;
    public static bool StaticCardBack;  


    public GameObject Hand;
    public int numberOfCardsInDeck;

   
    void Start()
    {
       numberOfCardsInDeck = PlayerDEck.deckSize;
       DisplayCard[0] = CardDatabase.cardClassList[displayID];
        
    }

     void Update()
    {
         
        _cardName = DisplayCard[0].cardName;
        _cardType = DisplayCard[0].cardType;
        _cardID = DisplayCard[0].cardID;
        _cardEdition = DisplayCard[0].cardEdition;

        cardNameText.text = _cardName;
        cardTypeText.text = _cardType;
        cardIDText.text = _cardID;
        cardEditionText.text = _cardEdition;

        



        // Hand = GameObject.Find("HandPanel");
        // if (this.transform.parent == Hand.transform.parent)
        // {
        //     cardBack = false;
        // }


        StaticCardBack = cardBack;

        // if (this.tag == "Clone")
        // {
        //     DisplayCard[0] = PlayerDEck.staticPlayerDeck[numberOfCardsInDeck - 1];
        //     numberOfCardsInDeck -= 1;
        //     PlayerDEck.deckSize -= 1;
        //     cardBack = false;
        //     this.tag = "Untagged";
        // }

    }

   
 
}
