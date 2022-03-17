using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Assets/Cards/New Card")]

public abstract class CardClass : ScriptableObject
{
    public string Name;
    public string ID;
    public string Edition;

    [TextArea]
    public string CardEffect;
    //public enum CardType {ITEM,ACTION,MANSION,WEAPON}

    

    public void Trash()
    {

    }

    public void Reveal()
    {

    }

    public void Gain()
    {

    }

    public void Attach()
    {

    }
}
