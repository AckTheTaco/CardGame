using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resource Collection", menuName = "Assets/Cards/Resource Collection/New Resource Collection")]
public class ResourceCollectionBase : ScriptableObject
{
   public List<ResourcePileBase> thisCollection; 
   public int Amount()
   {
      return thisCollection.Count;
   }

  
}
