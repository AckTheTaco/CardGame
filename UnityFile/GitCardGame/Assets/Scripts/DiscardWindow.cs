using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardWindow : MonoBehaviour
{
    [SerializeField] private ActionCardUI _actionCard;
    [SerializeField] private ItemCardUI _itemCard; 
    [SerializeField] private WeaponCardUI _weaponCard;

    [SerializeField] private GameObject _uiHandler;


  public void OpenDiscardZone()
  {
    gameObject.SetActive(true);
    Debug.Log($"{CardHandler.DiscardCount} cards in discard pile");
    _actionCard.refCard = null;
    _itemCard.refCard = null;
    _weaponCard.refCard = null;

     //Debug.Log(CardHandler.staticPlayerDiscard[i]);
        DisplayCard();

    // for (int i = 0; i < CardHandler.DiscardCount; i++)
    // {
           
    // }

  }

  public void CloseDiscardZone()
  {
    foreach (Transform child in GameObject.Find("DiscardHolder").transform)
    {
      Destroy(child.gameObject);
    } 

    gameObject.SetActive(false);
   
  }




  private void DisplayCard()
  {
    var discardCount = CardHandler.DiscardCount;
      
      for (int i = 0; i < discardCount; i++)
        {
          var TopDiscard = CardHandler.staticPlayerDiscard[i];
          Debug.Log(CardHandler.staticPlayerDiscard[i]);

          _uiHandler.GetComponent<UiHandler>().CreateCardUI(TopDiscard, GameObject.Find("DiscardHolder").transform);
        } 
  }
}
