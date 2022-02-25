using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiHandler : MonoBehaviour
{
    //Card Counting
    [SerializeField] private TMP_Text HandCountText, DeckCountText, TurnCountText, DiscardCountText, MansionCountText;

    // Player Stats
    [SerializeField] private TMP_Text CurrHealthText, MaxHealthText, DamageText, AmmoText, BuyText, ActionText, ExploreText, GoldText, XPText;



    void Start()
    {
        
    }


    void Update()
    {
        HandCountText.text = "Cards in Hand: " + GameManager.handCount.ToString();
        DeckCountText.text = "Deck: " + GameManager.deckListCount.ToString();
        TurnCountText.text = "Turn Count: " + GameManager.turnCount.ToString();
        DiscardCountText.text = "Discard: " + GameManager.discardCount.ToString();
        MansionCountText.text = "Mansion: " + GameManager.mansionCount.ToString();
        
        CurrHealthText.text = "Current Health: " + GameManager.playerCurrentHealth.ToString();
        MaxHealthText.text = "Max Health: " + GameManager.playerMaxHealth.ToString();
        
        DamageText.text = "Attack Damage: " + GameManager.Damage.ToString();
        AmmoText.text = "Ammo: " + GameManager.Ammo.ToString();
        BuyText.text = "Buys: " + GameManager.Buy.ToString();
        ActionText.text = "Actions: " + GameManager.Action.ToString();
        ExploreText.text = "Explores: " + GameManager.Explore.ToString();
        GoldText.text = "Gold: " + GameManager.Gold.ToString();
        XPText.text = "Decorations: " + GameManager.XP.ToString();
    }



    [Space]
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
