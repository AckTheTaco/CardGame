using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MansionCardUI : MonoBehaviour
{
    public MansionClass refCard;

    
    public TMP_Text cardNameText;
    public TMP_Text cardEditionText;
    public TMP_Text cardIDText;
    
    public TMP_Text cardHealthText;
    public TMP_Text cardDamageText;
    public TMP_Text cardDecorationsText;
    public TMP_Text cardEffectText;
    

   private void Update()
   {
        cardNameText.text = refCard.Name;
        cardIDText.text =  refCard.ID;
        cardEditionText.text =  refCard.Edition;
        cardHealthText.text = refCard.Health.ToString();
        cardDamageText.text = refCard.Damage.ToString();
        cardDecorationsText.text = refCard.Decorations.ToString();
        cardEffectText.text = refCard.CardEffect;
   }

   public void WhenDefeated()
   {
       return;
   }

   public void IfNotDefeated()
   {
       return;
   }

   public void WhenRevealed()
   {
       return;
   }
}