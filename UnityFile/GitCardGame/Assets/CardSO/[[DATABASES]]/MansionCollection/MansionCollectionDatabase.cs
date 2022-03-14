using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mansion Collection", menuName = "Assets/Cards/Databases/New Mansion Collection")]
public class MansionCollectionDatabase : ScriptableObject
{
   public List<MansionDatabaseClass> thisMansionCollection;
   public static MansionCollectionDatabase instance; 
}
