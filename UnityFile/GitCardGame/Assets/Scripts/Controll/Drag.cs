
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    GameObject parentToReturnTo = null;

   

    public void OnBeginDrag(PointerEventData eventData)
    {
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
        Debug.Log(eventData.pointerCurrentRaycast);
        


        if (eventData.pointerCurrentRaycast.gameObject.transform != parentToReturnTo.transform )  // this work? GameObject.Find("ExploreArea")
        {
            //this.transform.SetParent(GameObject.Find("ExploreArea").transform);
           
            this.transform.SetParent(parentToReturnTo.transform);
            
        }
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
}
