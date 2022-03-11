
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, ITransferable, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private GameObject parentToReturnTo = null;
    public string listName;
    string destinationHolder;


   

    public void OnBeginDrag(PointerEventData eventData)
    {
        listName = gameObject.transform.parent.name;
        ITransfering();
        parentToReturnTo = this.transform.parent.gameObject;
        this.transform.SetParent(this.transform.root);
        

        
        Debug.Log($"{this} will return to {parentToReturnTo}");
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        this.GetComponent<CanvasGroup>().alpha = .6f;
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
        
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
            Debug.Log($"{this.name} has returned to {parentToReturnTo.ToString()}");
            this.transform.SetParent(parentToReturnTo.transform);
        }
        
        


        // if (eventData.pointerCurrentRaycast.gameObject.transform != parentToReturnTo.transform )  // this work? GameObject.Find("ExploreArea")
        // {
        //     //this.transform.SetParent(GameObject.Find("ExploreArea").transform);
           
        //     this.transform.SetParent(parentToReturnTo.transform);
            
        // }
        // else
        // {
        //     this.transform.SetParent(parentToReturnTo.transform);
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
