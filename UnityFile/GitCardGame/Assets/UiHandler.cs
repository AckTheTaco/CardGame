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
}
