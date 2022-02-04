using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mansion Card", menuName = "Assets/Cards/New Mansion Card")]
public class MansionClass : CardClass
{
    //public enum Type {Infected, Token, Item};
    public int Health;
    public int Damage;
    public int Decorations;
    public string Type;

    public void WhenDefeated(GameObject Player)
    {

    }

    public void IfNotDefeated()
    {

    }

    public void WhenRevealed()
    {

    }

}
