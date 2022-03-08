using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Card", menuName = "Assets/Cards/New Item Card")]
[System.Serializable]
public class ItemClass : CardClass
{
    public int Cost;

    public ItemClass(string name, string id, string edition, string cardEffect)
    {
       ScriptableObject.CreateInstance("ItemClass");
        
        Name = name;
        ID = id;
        Edition = edition;
        CardEffect = cardEffect;
        
    }
}


