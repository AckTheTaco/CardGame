using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Player Deck", menuName = "Assets/Deck/New Player Deck")]
public class DeckList : ScriptableObject
{
  public List<CardClass> playerDeck = new List<CardClass>();


  
}
