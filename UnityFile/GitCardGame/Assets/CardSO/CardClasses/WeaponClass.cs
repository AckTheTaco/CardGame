using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Weapon Card", menuName = "Assets/Cards/New Weapon Card")]
public class WeaponClass : CardClass
{
   public enum enumType
   {
       Pistol,
       Knife,
       MachineGun,
       Shotgun,
       Minigun,
       Explosive,
       Magnum,
       Rifle,
       Bow,
       Melee
   }
   public string Type;
   

   public int Cost;
   public int Ammo;
   public int Damage;

   private void DamageEqualsAmmo(int CurrentAmmo)
   {
       Damage = CurrentAmmo;
   }

   public void AdditionalExplore(int BonusExplore)
   {
       // playerExplore += BonusExplore;
   }


}
