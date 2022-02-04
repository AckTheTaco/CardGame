using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mansion Database", menuName = "Assets/Cards/Databases/New Mansion Database")]
public class MansionDatabaseClass : ScriptableObject
{
   public List<CompleteCard> thisMansion; 
}
