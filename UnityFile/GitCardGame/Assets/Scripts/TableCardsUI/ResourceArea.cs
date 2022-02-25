using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class ResourceArea : MonoBehaviour
{
    //public ResourceCollectionBase _scenario;
    public ResourceCollectionBase usingScenario;
    public ActionCardUI actionPile;
    public ItemCardUI itemPile; 
    public WeaponCardUI weaponPile;
    public List<CompleteCard> theseScenarios = new List<CompleteCard>();
    
    // public WeaponClass[] theseWeapons;
    // public ActionClass[] theseActions;
    // public ItemClass[] theseItems;
    // public List<WeaponClass> thoseWeaponClass;
    // public List<ActionClass> thoseActionClass;
    // public List<ItemClass> thoseItemClass;

    //public List<CompleteCard> pile1, pile2, pile3, pile4, pile5, pile6, pile7, pile8, pile9, pile10, pile11, pile12, pile13, pile14, pile15, pile16, pile17, pile18;
    
    // public ItemClass CardClassToItemClass(CompleteCard cC)
    //     {
    //         return new ItemClass(cC.Name, cC.ID, cC.Edition, cC.CardEffect);
    //     }

    
    private void Start()
    {

        actionPile.refCard = null;
        itemPile.refCard = null;
        weaponPile.refCard = null;
        
        usingScenario  = ScriptableObject.Instantiate(CardHandler.Scenario); // Matches the UI ot the CardHandlers lists and cards
        
        

        //Debug.Log(usingScenario.thisCollection.Count);
        Debug.Log("Amount of Card piles in scenario " + usingScenario.Amount());

        
        
        #region TopCardAssignementInResourceArea
            
        
        int pilesCount = usingScenario.thisCollection.Count;
        for (int i = 0; i < pilesCount; i++)
        {
            string pile = "pile"+(i+1);
            var TopCardOfPile = usingScenario.thisCollection[i].thesePiles[0];
            
            
            if (TopCardOfPile.Type == "Action")
            {
                
                 
                var actionPileClone = actionPile;
                 
                actionPile.refCard = TopCardOfPile;
                ScriptableObject.Instantiate(actionPileClone, new Vector3(0,0) , Quaternion.identity, GameObject.Find(pile).transform);
                actionPile.name = TopCardOfPile.ToString();

                actionPile.refCard = null;
              
                // Debug.Log($"I Made an {TopCardOfPile.Name} {TopCardOfPile.Type} on {pile}");
                
            }
            else if (TopCardOfPile.Type == "Item" || TopCardOfPile.Type == "Ammo")
            {
                
                var itemPileClone = itemPile;

                itemPileClone.refCard = TopCardOfPile;

                Instantiate(itemPileClone, new Vector3(0,0) , Quaternion.identity, GameObject.Find(pile).transform);
                itemPileClone.name = TopCardOfPile.ToString();

                itemPileClone.refCard = null;
                
                //Debug.Log($"I Made an {TopCardOfPile.Name} {TopCardOfPile.Type} on {pile}");
               
                
            }
            else
            // if (TopCardOfPile.Type != "Item" && TopCardOfPile.Type != "Ammo" && TopCardOfPile.Type != "Action")
            {
                var weaponPileClone = weaponPile;

                weaponPileClone.refCard = TopCardOfPile;
                Instantiate(weaponPileClone, new Vector3(0,0) , Quaternion.identity, GameObject.Find(pile).transform);
                weaponPileClone.name = TopCardOfPile.ToString();

                weaponPileClone.refCard = null;

                //Debug.Log($"I Made an {TopCardOfPile.Name} {TopCardOfPile.Type} on {pile}");
                
            }

            #endregion
            

        } 

        
    }

    private void Update()
    {
        //Debug.Log(CardHandler.pile17[0]);
        //Debug.Log(usingScenario.thisCollection[0]);
        //Debug.Log(GameObject.Find("pile17").GetComponentsInChildren<WeaponCardUI>());
       // Debug.Log(GameObject.Find("pile1").transform.GetChild(0).GetComponent("ItemCardUI").GetComponent("ref Card").ToString());
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
