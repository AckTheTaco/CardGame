using UnityEngine;
using UnityEditor;


public class Utilities
{
    [MenuItem("Utilities/Comp-3 Interactive/Clear PlayerPrefs")]
    public static void DeletePlayerPrefs()
    {
        Debug.Log("All player prefs deleted");
        PlayerPrefs.DeleteAll();

    }
}
