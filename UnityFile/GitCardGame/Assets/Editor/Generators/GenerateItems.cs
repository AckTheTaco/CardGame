using UnityEngine;
using UnityEditor;
using System.IO;

public class GenerateItems
{
    private static string itemCSVPath = "/Editor/CSV/Items.csv";
    [MenuItem("Utilities//New/Generate Items")]
    public static void GenerateItem()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + itemCSVPath);

        foreach(string s in allLines)
        {
            string[] splitData = s.Split(',');

            CompleteCard itemClass = ScriptableObject.CreateInstance<CompleteCard>();
            itemClass.ID = splitData[0];
            itemClass.Name = splitData[1];            
            //CompleteCard.itemQuantity = int.Parse(splitData[2]);
            itemClass.Edition = splitData[2];
            itemClass.Type = splitData[3];
            itemClass.GoldCost = int.Parse(splitData[4]);
            itemClass.CardEffect = splitData[7];
            

            AssetDatabase.CreateAsset(itemClass, $"Assets/CardSO/Items/New Items/{itemClass.ID} {itemClass.Name}.asset");
            
        }

        //Need some logic here to catch duplicate names but different set/data on the same card

        AssetDatabase.SaveAssets();
    }
}
