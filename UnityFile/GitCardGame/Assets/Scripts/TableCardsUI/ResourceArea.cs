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
    
 

    
    private void Start()
    {

        actionPile.refCard = null;
        itemPile.refCard = null;
        weaponPile.refCard = null;
        
        usingScenario  = ScriptableObject.Instantiate(CardHandler.Scenario); // Matches the UI ot the CardHandlers lists and cards
        
        

        Debug.Log("Amount of Card piles in scenario " + usingScenario.Amount());

        
        
        #region TopCardAssignementInResourceArea
            
        
        int pilesCount = usingScenario.thisCollection.Count;

        for (int i = 0; i < pilesCount; i++)
        {
            string pile = "pile"+(i+1);
            
            var TopCardOfPile = usingScenario.thisCollection[i].thesePiles[0];
            
            
            if (TopCardOfPile.Type == "Action")
            {
                
                actionPile.refCard = null;
                var actionPileClone = actionPile;
                 
                actionPile.refCard = TopCardOfPile;

                actionPile.name = TopCardOfPile.ToString();

                ScriptableObject.Instantiate(actionPileClone, new Vector3(0,0) , Quaternion.identity, GameObject.Find(pile).transform);
                

                actionPile.refCard = null;
              
                // Debug.Log($"I Made an {TopCardOfPile.Name} {TopCardOfPile.Type} on {pile}");
                
            }
            else if (TopCardOfPile.Type == "Item" || TopCardOfPile.Type == "Ammo")
            {
                itemPile.refCard = null;
                var itemPileClone = itemPile;
                

                itemPileClone.refCard = TopCardOfPile;

                itemPileClone.name = TopCardOfPile.ToString();

                Instantiate(itemPileClone, new Vector3(0,0) , Quaternion.identity, GameObject.Find(pile).transform);
                

                itemPileClone.refCard = null;
                
                //Debug.Log($"I Made an {TopCardOfPile.Name} {TopCardOfPile.Type} on {pile}");
               
                
            }
            else
            // if (TopCardOfPile.Type != "Item" && TopCardOfPile.Type != "Ammo" && TopCardOfPile.Type != "Action")
            {
                weaponPile.refCard = null;
                var weaponPileClone = weaponPile;
                

                weaponPileClone.refCard = TopCardOfPile;

                weaponPileClone.name = TopCardOfPile.ToString();
                
                Instantiate(weaponPileClone, new Vector3(0,0) , Quaternion.identity, GameObject.Find(pile).transform);
                

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
