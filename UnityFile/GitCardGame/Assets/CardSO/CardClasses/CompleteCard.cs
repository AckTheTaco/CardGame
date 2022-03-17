using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Complete Card", menuName = "Assets/Cards/New Complete Card")]
[System.Serializable]
public class CompleteCard : CardClass, IPlayable
{
    public string Type;
    public int GoldCost;
    public int AmmoCost;
    public int Damage;

    public int AmmoGiven;
    public int GoldGiven;
    [Space]
    public int Health;
    
    public int Decorations;

    
    public List<CompleteCard> ListPosition;

    public void IPlayed()
    {
        Debug.Log($"This card was played");
    }


}
