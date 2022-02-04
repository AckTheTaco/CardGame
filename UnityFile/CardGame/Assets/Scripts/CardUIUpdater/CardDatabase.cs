using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
   public static List<ACardClass> cardClassList = new List<ACardClass>();

  
   void Awake()
   {
       cardClassList.Add(new ACardClass("CardName", "CardType", "CardID", "CardEdition"));
       cardClassList.Add(new ACardClass("john", "human", "HU-001", "Premier"));
       cardClassList.Add( new ACardClass("Zim", "Alien", "AN-001", "Space"));
       cardClassList.Add(new ACardClass("Keven", "Animal", "AN-002", "Alien"));
       cardClassList.Add( new ACardClass( "Wowza", "Thing", "TH-003", "Last") );
   }

}
