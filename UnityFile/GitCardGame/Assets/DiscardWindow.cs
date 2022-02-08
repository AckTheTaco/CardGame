using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardWindow : MonoBehaviour
{
    [SerializeField] private ActionCardUI _actionCard;
    [SerializeField] private ItemCardUI _itemCard; 
    [SerializeField] private WeaponCardUI _weaponCard;


  public void OpenDiscardZone()
  {
    gameObject.SetActive(true);
    Debug.Log(CardHandler.DiscardCount);

    for (int i = 0; i < CardHandler.DiscardCount; i++)
    {
        Debug.Log(CardHandler.PlayerDiscard[i]);
        DisplayCard();    
    }

  }

  public void CloseDiscardZone()
  {
      gameObject.SetActive(false);
  }




  private void DisplayCard()
  {
    var discardCount = CardHandler.DiscardCount;
    
      
      for (int i = 0; i < discardCount; i++)
        {
            var TopDiscard = CardHandler.PlayerDiscard[i];
            //string pile = "pile"+(i+1);
           
            
            
            if (TopDiscard.Type == "Action")
            {
                
                 
                var actionClone = _actionCard;
                 
                actionClone.refCard = TopDiscard;
                ScriptableObject.Instantiate(actionClone, new Vector3(0,0) , Quaternion.identity, GameObject.Find("DiscardHolder").transform);
                actionClone.name = TopDiscard.ToString();

                actionClone.refCard = null;
              
                Debug.Log($"I Made an {TopDiscard.Name} {TopDiscard.Type} in the discardPile");
                
            }
            else if (TopDiscard.Type == "Item" || TopDiscard.Type == "Ammo")
            {
                
                var itemClone = _itemCard;

                itemClone.refCard = TopDiscard;

                Instantiate(itemClone, new Vector3(0,0) , Quaternion.identity, GameObject.Find("DiscardHolder").transform);
                itemClone.name = TopDiscard.ToString();

                itemClone.refCard = null;
                
                Debug.Log($"I Made an {TopDiscard.Name} {TopDiscard.Type} in the discardPile");
               
                
            }
            else
            // if (TopDiscard.Type != "Item" && TopDiscard.Type != "Ammo" && TopDiscard.Type != "Action")
            {
                var weaponClone = _weaponCard;

                weaponClone.refCard = TopDiscard;
                Instantiate(weaponClone, new Vector3(0,0) , Quaternion.identity, GameObject.Find("DiscardHolder").transform);
                weaponClone.name = TopDiscard.ToString();

                weaponClone.refCard = null;

                Debug.Log($"I Made an {TopDiscard.Name} {TopDiscard.Type} in the discardPile");
                
            }

            
            

        } 
  }
}
