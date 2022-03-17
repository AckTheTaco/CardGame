using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMansion : MonoBehaviour
{
    public MansionCardUIsmall mansionCardExplore;
    [SerializeField]private int i = 0;
    public void TopMansionCard()
    {
        if (GameManager.instance.Explore > i)
        {
            mansionCardExplore.refCard = Instantiate(CardHandler.instance.listDictionary["MansionDeck"][i]);
            Instantiate(mansionCardExplore, new Vector3(0,0) , Quaternion.identity, GameObject.Find("ExploreArea").transform);
            Debug.Log(mansionCardExplore.refCard.ToString());
            mansionCardExplore.refCard = null;
            i++;
        }
        else
        {
            print("You dont have enough explores available");
        }
        
    }
}
