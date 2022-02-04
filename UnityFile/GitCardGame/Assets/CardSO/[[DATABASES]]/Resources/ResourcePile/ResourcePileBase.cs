using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resource Pile", menuName = "Assets/Cards/Resource Pile/New Resource Pile")]
public class ResourcePileBase : ScriptableObject
{
    public List<CompleteCard> thesePiles;
    
}
