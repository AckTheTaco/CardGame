using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiHandler : MonoBehaviour
{
    //Card Counting
    [Space]
    [SerializeField] private TMP_Text HandCountText, DeckCountText, TurnCountText, DiscardCountText, MansionCountText;
    [Space]
    // Player Stats
    [SerializeField] private TMP_Text CurrHealthText, MaxHealthText, DamageText, AmmoText, BuyText, ActionText, ExploreText, GoldText, XPText;



    void Start()
    {
        
    }


    void Update()
    {
        HandCountText.text = "" + GameManager.handCount.ToString(); // Added Icon beside number and removed words
        DeckCountText.text = " " + GameManager.deckListCount.ToString(); // Added Icon beside number and removed words
        
        TurnCountText.text = " Turn " + GameManager.turnCount.ToString(); // Added Icon beside number and removed words
        
        DiscardCountText.text = " " + GameManager.discardCount.ToString(); // Added Discard count to the Discard button
        MansionCountText.text = "" + GameManager.mansionCount.ToString(); // Added Icon along side number

        
        CurrHealthText.text = " " + GameManager.playerCurrentHealth.ToString() + " / " + GameManager.playerMaxHealth.ToString(); // Combined CUrrent and Max Health in one line and Added Icon
        
       
     
        BuyText.text = "" + GameManager.Buy.ToString(); // Icon added with number
        ActionText.text = "Actions: " + GameManager.Action.ToString();
        ExploreText.text = "Explores: " + GameManager.Explore.ToString();
        
        DamageText.text = "Attack Damage: " + GameManager.Damage.ToString();
        AmmoText.text = "Ammo: " + GameManager.Ammo.ToString();
        GoldText.text = "Gold: " + GameManager.Gold.ToString();
        
        XPText.text = " " + GameManager.XP.ToString(); // Decorations Medal Icon
    }



    [Space]
    [SerializeField] private ActionCardUI _actionCard;
    [SerializeField] private ItemCardUI _itemCard; 
    [SerializeField] private WeaponCardUI _weaponCard;

    public void CreateCardUI(CompleteCard _thisCard, Transform _location)
    {
        

        if (_thisCard.Type == "Action")
        {
            _actionCard.refCard = null;
            var actionClone = _actionCard;
            actionClone.refCard = null;

            actionClone.name = _thisCard.ToString();
            actionClone.refCard = _thisCard;
            

            ScriptableObject.Instantiate(actionClone, new Vector3(0,0) , Quaternion.identity, _location);

            actionClone.refCard = null;

            Debug.Log($"UpdateCardUI made a {_thisCard.name} {_thisCard.Type} in the {_location.ToString()}");
        } 
        else if (_thisCard.Type == "Item" || _thisCard.Type == "Ammo")
        {
            _itemCard.refCard = null;
            var itemClone = _itemCard;
            itemClone.refCard = null;

            itemClone.refCard = _thisCard;
            itemClone.name = _thisCard.name.ToString();

            ScriptableObject.Instantiate(itemClone, new Vector3(0,0) , Quaternion.identity, _location);

            itemClone.refCard = null;

            Debug.Log($"UpdateCardUI made a {_thisCard.name} {_thisCard.Type} in the {_location.ToString()}");
        }       
            else
        {
            _weaponCard.refCard = null;
            var weaponClone = _weaponCard;
            weaponClone.refCard = null;

            weaponClone.refCard = _thisCard;
            weaponClone.name = _thisCard.ToString();

            ScriptableObject.Instantiate(weaponClone, new Vector3(0,0) , Quaternion.identity, _location);

            weaponClone.refCard = null;

            Debug.Log($"UpdateCardUI made a {_thisCard.name} {_thisCard.Type} in the {_location.ToString()}");
        }
    }
}
