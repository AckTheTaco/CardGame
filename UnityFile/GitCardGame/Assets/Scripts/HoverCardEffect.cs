using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverCardEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   public void OnPointerEnter(PointerEventData eventData)
   {
        print("you moused over" + gameObject.name);
        
   }

   public void OnPointerExit(PointerEventData eventData)
   {
        print("your mouse left" + gameObject.name);
   }
}
