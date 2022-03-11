using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMansion : MonoBehaviour
{
    public MansionCardUI mansionCardExplore;
    public void TopMansionCard()
    {
        mansionCardExplore.refCard = Instantiate(CardHandler.staticMansionDeck[0]);
        Instantiate(mansionCardExplore, new Vector3(0,0) , Quaternion.identity, GameObject.Find("ExploreArea").transform);
        Debug.Log(mansionCardExplore.refCard.ToString());
        mansionCardExplore.refCard = null;
    }
}
