using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Action Card", menuName = "Assets/Cards/New Action Card")]
public class ActionClass : CardClass
{
   public int Cost;
   
   

   public void DrawCard(int DrawCount)
   {
       /*
        if (int i = 0; i < DrawCouunt; i++)
        {
            playerHand.Add(playerDeck[0]);
            playerDeck.Remove[0];
        }
       */
   }

   public void AdditionalAction(int AddAction)
   {
       // playerAction += AddAction;
   }

   public void AdditionalBuys(int AddBuys)
   {
       // playerBuys += AddBuys;
   }

   public void AdditionalGold(int AddGold)
   {
       // playerGold += AddGold;
   }

   public void AdditionalAmmo(int AddAmmo)
   {
       // playerAmmo += AddAmmo'
   }

    public void AdditionalDamageForEachWeapon(int AddDamage, int WeaponCount)
    {
        for (int i = 0; i <= WeaponCount; i++)
        {
            // playerDamage += AddDamage
        }
    }

    public void TopOfDeck(GameObject CardToMove, List<CardClass> Current, List<CardClass> Destination)
    {
        // playerLocationCardShouldGo.Insert(Index of CardToMove from location it currently is in, [0])
        // Destination.Insert[0](CardToMove);
        // Current.Remove[i].Remove(CardToMove);
    }



}
