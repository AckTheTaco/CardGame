using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Empty Player Deck", menuName = "Assets/Cards/Player Deck/New Empty Player Deck" )]
public class EmptyPlayerDeck : ScriptableObject
{
   public List<CompleteCard> aDeck; 
}
