using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardWindow : MonoBehaviour
{
    [SerializeField] private ActionCardUI _actionCard;
    [SerializeField] private ItemCardUI _itemCard; 
    [SerializeField] private WeaponCardUI _weaponCard;

    [SerializeField] public GameObject _discardWindow;

   


  public void OpenDiscardZone()
  {
    Instantiate(_discardWindow, GameObject.Find("Canvas").transform);
    Debug.Log($"{CardHandler.DiscardCount} cards in discard pile");
    _actionCard.refCard = null;
    _itemCard.refCard = null;
    _weaponCard.refCard = null;
      
    DisplayCard();

  }

  public void CloseDiscardZone()
  {
    foreach (Transform child in GameObject.Find("DiscardHolder").transform)
    {
      Destroy(child.gameObject);
    } 
    Destroy(gameObject);
  }




  private void DisplayCard()
  {
    var discardCount = CardHandler.DiscardCount;
      
      for (int i = 0; i < discardCount; i++)
        {
          var TopDiscard = CardHandler.staticPlayerDiscard[i];
          Debug.Log(CardHandler.staticPlayerDiscard[i]);

          UiHandler.instance.CreateCardUI(TopDiscard, GameObject.Find("DiscardHolder").transform);
        } 
  }
}
