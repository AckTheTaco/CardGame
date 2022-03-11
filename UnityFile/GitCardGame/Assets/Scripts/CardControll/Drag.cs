
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Drag : MonoBehaviour, ITransferable, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private GameObject _parentToReturnTo = null;
    public string listName;
    string destinationHolder;

    private RaycastHit2D[] _raycastAll;

    private void Awake()
    {
        
    }
   

    public void OnBeginDrag(PointerEventData eventData)
    {
        listName = gameObject.transform.parent.name;
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
        _raycastAll = Physics2D.RaycastAll(transform.position, transform.forward, 100f);
        
        Debug.Log($"{_raycastAll.Length} raycast lenghts");

        
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        
        
        
        

        Debug.Log(eventData.pointerCurrentRaycast.gameObject.transform.name);
        destinationHolder = eventData.pointerCurrentRaycast.gameObject.transform.name;
        ITransfered();
        Debug.Log(this.name.Contains("WE-"));

        if (name.Contains("WE-") && destinationHolder == "WeaponHolder")
        {
            Debug.Log($"{this.name} could move to {destinationHolder.ToString()}");
            this.gameObject.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
        }
        else if (name.Contains("AC-") && destinationHolder == "ActionHolder")
        {
            Debug.Log($"{this.name} could move to {destinationHolder.ToString()}");
            this.gameObject.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
        }
        else if ((name.Contains("IT-") || name.Contains("AM-")) && destinationHolder == "ItemHolder")
        {
            Debug.Log($"{this.name} could move to {destinationHolder.ToString()}");
            this.gameObject.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
        }
        else
        {
            Debug.Log($"{this.name} has returned to {_parentToReturnTo.ToString()}");
            this.transform.SetParent(_parentToReturnTo.transform);
        }
        
        


        // if (eventData.pointerCurrentRaycast.gameObject.transform != _parentToReturnTo.transform )  // this work? GameObject.Find("ExploreArea")
        // {
        //     //this.transform.SetParent(GameObject.Find("ExploreArea").transform);
           
        //     this.transform.SetParent(_parentToReturnTo.transform);
            
        // }
        // else
        // {
        //     this.transform.SetParent(_parentToReturnTo.transform);
        // }
        // if (eventData.pointerCurrentRaycast.gameObject == GameObject.Find("Card Placees"))
        // {
        //     this.transform.SetParent(GameObject.Find("Card Placees").transform);
        // }
        
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
