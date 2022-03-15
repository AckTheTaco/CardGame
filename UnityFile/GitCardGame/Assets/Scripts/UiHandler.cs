using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiHandler : MonoBehaviour
{
    public static UiHandler instance;
    [Space]
    [SerializeField] private TMP_Text _avatarName;
    //Card Counting
    [Space]
    [SerializeField] private TMP_Text HandCountText, DeckCountText, TurnCountText, DiscardCountText, MansionCountText;
    [Space]
    // Player Stats
    [SerializeField] private TMP_Text CurrHealthText, MaxHealthText, DamageText, AmmoText, BuyText, ActionText, ExploreText, GoldText, XPText;


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
        
    }


    void Update()
    {
        HandCountText.text = "" + GameManager.instance.handCount.ToString(); // Added Icon beside number and removed words
        DeckCountText.text = " " + GameManager.instance.deckListCount.ToString(); // Added Icon beside number and removed words
        
        TurnCountText.text = " Turn " + GameManager.instance.turnCount.ToString(); // Added Icon beside number and removed words
        
        DiscardCountText.text = " " + GameManager.instance.discardCount.ToString(); // Added Discard count to the Discard button
        MansionCountText.text = "" + GameManager.instance.mansionCount.ToString(); // Added Icon along side number

        
        CurrHealthText.text = " " + GameManager.instance.playerCurrentHealth.ToString() + " / " + GameManager.instance.playerMaxHealth.ToString(); // Combined CUrrent and Max Health in one line and Added Icon
        
       
     
        BuyText.text = "" + GameManager.instance.Buy.ToString(); // Icon added with number
        ActionText.text = "" + GameManager.instance.Action.ToString();
        ExploreText.text = "" + GameManager.instance.Explore.ToString();
        
        DamageText.text = "" + GameManager.instance.Damage.ToString();
        AmmoText.text = "" + GameManager.instance.Ammo.ToString();
        GoldText.text = "" + GameManager.instance.Gold.ToString();
        
        XPText.text = " " + GameManager.instance.XP.ToString(); // Decorations Medal Icon

        _avatarName.text = GameManager.instance.avatar.name.Substring(GameManager.instance.avatar.name.IndexOf(" "));
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
