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
        usingScenario  = ScriptableObject.Instantiate(CardHandler.Scenario); // Matches the UI ot the CardHandlers lists and cards
        
        

        Debug.Log(usingScenario.thisCollection.Count);
        Debug.Log("this is the amount" + usingScenario.Amount());

        
        
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
                
                Debug.Log($"I Made an {TopCardOfPile.Name} {TopCardOfPile.Type} on {pile}");
               
                
            }
            else
            // if (TopCardOfPile.Type != "Item" && TopCardOfPile.Type != "Ammo" && TopCardOfPile.Type != "Action")
            {
                var weaponPileClone = weaponPile;

                weaponPileClone.refCard = TopCardOfPile;
                Instantiate(weaponPileClone, new Vector3(0,0) , Quaternion.identity, GameObject.Find(pile).transform);
                weaponPileClone.name = TopCardOfPile.ToString();

                weaponPileClone.refCard = null;

                Debug.Log($"I Made an {TopCardOfPile.Name} {TopCardOfPile.Type} on {pile}");
                
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


    // void CreateItemCard(ItemCardUI itemCard, )
    // {

    // }
}
