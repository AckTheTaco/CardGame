using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionCardUI : MonoBehaviour
{
   
    public CompleteCard refCard;
    

     // this is an action card
    
    public TMP_Text cardNameText;
    public TMP_Text cardCostText;
    public TMP_Text cardEffectText;
    public TMP_Text cardEditionText;
    public TMP_Text cardIDText;

   private void Update()
   {
     cardNameText.text = refCard.Name;
     cardCostText.text = refCard.Cost.ToString();
     cardEffectText.text = refCard.CardEffect;
     cardIDText.text =  refCard.ID;
     cardEditionText.text =  refCard.Edition;

     if (this.transform.parent.gameObject.name != "PlayerHandHolder" )
     {     
          GetComponent<AspectRatioFitter>().aspectMode = AspectRatioFitter.AspectMode.WidthControlsHeight;
          //Debug.Log(GetComponent<AspectRatioFitter>().aspectMode + " This is in hand");
     }
     //    else{
     //        GetComponent<AspectRatioFitter>().aspectMode = AspectRatioFitter.AspectMode.WidthControlsHeight;
     //        //Debug.Log("not in hand");
     //    }
   }

   
}
