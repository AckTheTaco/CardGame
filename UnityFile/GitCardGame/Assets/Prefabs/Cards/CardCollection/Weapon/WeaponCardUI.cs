using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponCardUI : MonoBehaviour
{
    public CompleteCard refCard;

    
    public TMP_Text cardNameText;
    public TMP_Text cardCostText;
    public TMP_Text cardEffectText;
    public TMP_Text cardAmmoText;
    public TMP_Text cardDamageText;
    public TMP_Text cardWeaponType;


    public TMP_Text cardEditionText;
    public TMP_Text cardIDText;

   private void Update()
   {
        cardNameText.text = refCard.Name;
        cardCostText.text = refCard.Cost.ToString();
        cardEffectText.text = refCard.CardEffect;
        cardAmmoText.text = refCard.Ammo.ToString();
        cardDamageText.text = refCard.Damage.ToString();
        cardWeaponType.text = refCard.Type;


        cardIDText.text =  refCard.ID;
        cardEditionText.text =  refCard.Edition;

         if (this.transform.parent.gameObject.name != "PlayerHandHolder" )
     {     
          GetComponent<AspectRatioFitter>().aspectMode = AspectRatioFitter.AspectMode.WidthControlsHeight;
          //Debug.Log(GetComponent<AspectRatioFitter>().aspectMode + " This is in hand");
     }
   }
}
