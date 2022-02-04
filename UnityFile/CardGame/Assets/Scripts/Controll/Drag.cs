
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform parentToReturnTo = null;

   

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        //this.transform.SetParent(this.transform.parent.parent);
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
        


        if (eventData.pointerCurrentRaycast.gameObject.transform != parentToReturnTo)  // this work? GameObject.Find("ExploreArea")
        {
            //this.transform.SetParent(GameObject.Find("ExploreArea").transform);

            this.transform.SetParent(parentToReturnTo);
            
        }
        // if (eventData.pointerCurrentRaycast.gameObject == GameObject.Find("Card Placees"))
        // {
        //     this.transform.SetParent(GameObject.Find("Card Placees").transform);
        // }
            
            
        
        
        
        
        
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
        this.GetComponent<CanvasGroup>().alpha = 1f;
    }
}
