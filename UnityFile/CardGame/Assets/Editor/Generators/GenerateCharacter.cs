using UnityEngine;
using UnityEditor;
using System.IO;

public class GenerateCharater
{
    private static string itemCSVPath = "/Editor/CSV/Characters.csv";
    [MenuItem("Utilities//New/Generate Characters")]
    public static void GenerateCharacters()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + itemCSVPath);

        foreach(string s in allLines)
        {
            string[] splitData = s.Split(',');

            CharacterClass characterClass = ScriptableObject.CreateInstance<CharacterClass>();
            characterClass.ID = splitData[0];
            characterClass.Name = splitData[1];
            characterClass.Edition = splitData[2];
            characterClass.Health = int.Parse(splitData[3]);
            characterClass.CardEffect = splitData[5];
            // characterClass.Lvl1Req = 0;
            // characterClass.Lvl2Req = 1;
            

            AssetDatabase.CreateAsset(characterClass, $"Assets/CardSO/Characters/{characterClass.ID} {characterClass.Name}.asset");
            
        }

        //Need some logic here to catch duplicate names but different set/data on the same card

        AssetDatabase.SaveAssets();
    }
}
