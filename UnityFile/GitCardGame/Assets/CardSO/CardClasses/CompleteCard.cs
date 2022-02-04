using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Complete Card", menuName = "Assets/Cards/New Complete Card")]
public class CompleteCard : CardClass
{
    public string Type;
    public int Cost;
    public int Ammo;
    public int Damage;
    [Space]
    public int Health;
    //public int Damage;
    public int Decorations;
}
