using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scenario Collection", menuName = "Assets/Cards/Resource Collection/New Scenario Collection")]
public class ScenarioCollection : ScriptableObject
{
    public List<ResourceCollectionBase> thisScenarioCollection;
    public static ScenarioCollection instance;
}
