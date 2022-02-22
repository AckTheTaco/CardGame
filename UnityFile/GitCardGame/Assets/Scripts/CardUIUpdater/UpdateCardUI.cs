using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpdateCardUI : MonoBehaviour
{

    //public CardClass _thisCard;

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

    [SerializeField] private ActionCardUI _actionCard;
    [SerializeField] private ItemCardUI _itemCard; 
    [SerializeField] private WeaponCardUI _weaponCard;

    
    public void CreateCardUI(CompleteCard _thisCard, Transform _location)
    {
        

        if (_thisCard.Type == "Action")
        {
            var actionClone = _actionCard;

            actionClone.refCard = _thisCard;
            actionClone.name = _thisCard.ToString();

            ScriptableObject.Instantiate(actionClone, new Vector3(0,0) , Quaternion.identity, _location);

            actionClone.refCard = null;

            Debug.Log($"UpdateCardUI made a {_thisCard.name} {_thisCard.Type} in the {_location.ToString()}");
        } 
        else if (_thisCard.Type == "Item" || _thisCard.Type == "Ammo")
        {
            var itemClone = _itemCard;

            itemClone.refCard = _thisCard;
            itemClone.name = _thisCard.name.ToString();

            ScriptableObject.Instantiate(itemClone, new Vector3(0,0) , Quaternion.identity, _location);

            itemClone.refCard = null;

            Debug.Log($"UpdateCardUI made a {_thisCard.name} {_thisCard.Type} in the {_location.ToString()}");
        }       
            else
        {
            var weaponClone = _weaponCard;

            weaponClone.refCard = _thisCard;
            weaponClone.name = _thisCard.ToString();

            ScriptableObject.Instantiate(weaponClone, new Vector3(0,0) , Quaternion.identity, _location);

            weaponClone.refCard = null;

            Debug.Log($"UpdateCardUI made a {_thisCard.name} {_thisCard.Type} in the {_location.ToString()}");
        }
    }

    
}
