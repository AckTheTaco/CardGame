using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class GenerateOther
{
    private static string othersCSVpath = "/Editor/CSV/Other.csv";


   // [MenuItem("Utilities/New/Generate Others")]
    public static void GenerateOthers()
   {
       string[] allLines = File.ReadAllLines(Application.dataPath + othersCSVpath);

       foreach (string s in allLines)
       {
           string[] splitData = s.Split(',');
           
           CardClass otherCards = ScriptableObject.CreateInstance<CardClass>();
           otherCards.ID = splitData[0];
           otherCards.Name = splitData[1].Replace("/"," ");
           otherCards.Edition = splitData[2];
        //    otherCards.Type = splitData[3];
        //    otherCards.Cost = splitData[4].Replace("null","");
        //    otherCards.Ammo = splitData[5].Replace("null","");
        //    otherCards.Damage = splitData[6].Replace("null","");
        //    otherCards.Effect = splitData[7].Replace("~","").Replace("null","");

           AssetDatabase.CreateAsset(otherCards, $"Assets/ScriptableObjects/Others/{otherCards.ID} {otherCards.Name}.asset");
       }

       AssetDatabase.SaveAssets();
   }
}