
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Drag : MonoBehaviour, ITransferable, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject _parentToReturnTo = null;
    public string listName;

    public string oldList;

    public string homeList;
    string destinationHolder;

    private List<RaycastResult> _raycastAllHits = new List<RaycastResult>();

    
    private void Start()
    {
        

    }
   

    public void OnBeginDrag(PointerEventData eventData)
    {
        homeList = gameObject.transform.parent.name;

        oldList = homeList;
        

        ITransfering();
        _parentToReturnTo = this.transform.parent.gameObject;
        this.transform.SetParent(this.transform.root);
        

        
        Debug.Log($"{this} will return to {_parentToReturnTo}");
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        this.GetComponent<CanvasGroup>().alpha = .6f;
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
      
        EventSystem.current.RaycastAll(eventData, _raycastAllHits);
        
        for (int i = 0; i < _raycastAllHits.Count; i++)
        {
            var hitName = _raycastAllHits[i].gameObject.name;

            
            
            if (name.Contains("WE-") && hitName == "WeaponHolder")
            {
                

                _parentToReturnTo = _raycastAllHits[i].gameObject;
                
                this.transform.SetParent(_parentToReturnTo.transform);
                
                listName = gameObject.transform.parent.name;
                homeList = listName;
                
                CardHandler.instance.ActiveWeapons
                    .Add(GetComponent<WeaponCardUI>().refCard);
                CardHandler.instance.PlayerHand
                    .Remove(GetComponent<WeaponCardUI>().refCard);
                
               
            }
            else if (name.Contains("AC-") && hitName == "ActionHolder")
            {
                

                _parentToReturnTo = _raycastAllHits[i].gameObject;
                
                this.transform.SetParent(_parentToReturnTo.transform);

                

                listName = gameObject.transform.parent.name;
                homeList = listName;

               
                

                CardHandler.instance.ActiveActions
                    .Add(GetComponent<ActionCardUI>().refCard);
                CardHandler.instance.PlayerHand
                    .Remove(GetComponent<ActionCardUI>().refCard);
                
                
            }
            else if ((name.Contains("IT-") || name.Contains("AM-")) && hitName == "ItemHolder")
            {
                

                _parentToReturnTo = _raycastAllHits[i].gameObject;
                
                this.transform.SetParent(_parentToReturnTo.transform);

                

                listName = gameObject.transform.parent.name;
                homeList = listName;

               
                

                CardHandler.instance.ActiveItems
                    .Add(GetComponent<ItemCardUI>().refCard);
                CardHandler.instance.PlayerHand
                    .Remove(GetComponent<ItemCardUI>().refCard);
                
                
            }
            else
            {
                Debug.Log($"{this.name} has returned to {_parentToReturnTo.ToString()}");
                this.transform.SetParent(_parentToReturnTo.transform);
            }
        }

        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
        this.GetComponent<CanvasGroup>().alpha = 1f;
    }

    public void ITransfering()
    {
        Debug.Log($"You are tring to transfer {this.name} from {listName}");
        //Debug.Log(CardHandler.pile1[1].name);
    }
    public void ITransfered()
    {

        if (destinationHolder == "WeaponHolder")
        {
            Debug.Log("This Is the Area for weapons");
            Debug.Log($"You transfered to {destinationHolder}");
        }
        

    }

}
