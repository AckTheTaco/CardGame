using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Card", menuName = "Assets/Cards/New Character Card")]
public class CharacterClass : CardClass
{
    public int Health;
    public int Lvl1Req;
    public int Lvl2Req;
}
