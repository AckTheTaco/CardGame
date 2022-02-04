using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Collection", menuName = "Assets/Cards/Character Collection/New Character Collection")]
public class CharacterCollection : ScriptableObject
{
   public List<CharacterClass> characterCollection; 
}
