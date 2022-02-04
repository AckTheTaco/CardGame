using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class GenerateMansion
{
    private static string mansionsCSVpath = "/Editor/CSV/Mansion.csv";


   [MenuItem("Utilities/New/Generate Mansions")]
    public static void GenerateMansions()
   {
       string[] allLines = File.ReadAllLines(Application.dataPath + mansionsCSVpath);

       foreach (string s in allLines)
       {
            string[] splitData = s.Split(',');
           
            CompleteCard mansionCards = ScriptableObject.CreateInstance<CompleteCard>();
            mansionCards.ID = splitData[0];
            mansionCards.Name = splitData[1].Replace("/"," ");
            mansionCards.Edition = splitData[2];
            mansionCards.Type = splitData[3];
            mansionCards.Health = int.Parse(splitData[4].Replace("null","0"));
            mansionCards.Damage = int.Parse(splitData[5].Replace("null","0"));
            mansionCards.Decorations = int.Parse(splitData[6].Replace("null","0"));
            mansionCards.CardEffect = splitData[7].Replace("~","").Replace("null"," ");

           AssetDatabase.CreateAsset(mansionCards, $"Assets/CardSO/MansionCards/{mansionCards.ID} {mansionCards.Name}.asset");
       }

       AssetDatabase.SaveAssets();
   }
}