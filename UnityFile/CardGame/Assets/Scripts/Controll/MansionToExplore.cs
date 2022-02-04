using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MansionToExplore : MonoBehaviour
{
    
    public GameObject Explore;
    public GameObject ExploreCard;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Explore = GameObject.Find("ExploreArea");
        ExploreCard.transform.SetParent(Explore.transform);
        ExploreCard.transform.localScale = Vector3.one;
        ExploreCard.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        ExploreCard.transform.eulerAngles = new Vector3(25,0,0);
    }
}
