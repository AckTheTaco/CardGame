using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class GenerateWeapons
{
    private static string weaponsCSVpath = "/Editor/CSV/Weapons.csv";


   [MenuItem("Utilities/New/Generate Weapons")]
    public static void GenerateWeapon()
   {
       string[] allLines = File.ReadAllLines(Application.dataPath + weaponsCSVpath);

       foreach (string s in allLines)
       {
            string[] splitData = s.Split(',');
            
            CompleteCard weaponCards = ScriptableObject.CreateInstance<CompleteCard>();
            weaponCards.ID = splitData[0];
            weaponCards.Name = splitData[1].Replace("/"," ");
            weaponCards.Edition = splitData[2];
            weaponCards.Type = splitData[3];
            weaponCards.Cost = int.Parse(splitData[4].Replace("null","").Replace("X", "0"));
            weaponCards.Ammo = int.Parse(splitData[5].Replace("null","").Replace("X", "0"));
            weaponCards.Damage = int.Parse(splitData[6].Replace("null","").Replace("X", "0"));
            weaponCards.CardEffect = splitData[7].Replace("~","").Replace("null","");

           AssetDatabase.CreateAsset(weaponCards, $"Assets/CardSO/Weapons/{weaponCards.ID} {weaponCards.Name}.asset");
       }

       AssetDatabase.SaveAssets();
   }
}
