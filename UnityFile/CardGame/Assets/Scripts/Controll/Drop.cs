using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler, IPointerExitHandler, IPointerEnterHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("It Dropped");
        Debug.Log(eventData.pointerCurrentRaycast);
        // if (eventData.pointerDrag != null)
        // {
        //     eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        // }
        return;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

}
