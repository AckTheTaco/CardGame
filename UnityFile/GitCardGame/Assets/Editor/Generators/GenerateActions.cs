using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;

public class GenerateActions
{
   private static string actionsCSVpath = "/Editor/CSV/Actions.csv";
   

   [MenuItem("Utilities/New/Generate Actions")]

   public static void GenerateActionsCards()
   {
       string[] allLines = File.ReadAllLines(Application.dataPath + actionsCSVpath);

       foreach (string s in allLines)
        {
            string[] splitData = s.Split(',');
            
            CompleteCard actionCards = ScriptableObject.CreateInstance<CompleteCard>();
            actionCards.ID = splitData[0];
            actionCards.Name = splitData[1];
            actionCards.Edition = splitData[2];
            actionCards.GoldCost = int.Parse(splitData[4].Replace("null","0"));
            actionCards.CardEffect = splitData[7].Replace("~","");
            actionCards.Type = "Action";

           AssetDatabase.CreateAsset(actionCards, $"Assets/CardSO/Actions/{actionCards.ID} {actionCards.Name}.asset");
       }

       AssetDatabase.SaveAssets();
   }

    

}


