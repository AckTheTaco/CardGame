using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandSpread : MonoBehaviour
{
    int handCount;
    
   
    int newHand;
    int adjusted;
    private void Start()
    {
        GetComponent<HorizontalLayoutGroup>().spacing = -162.3f;
        float handspacing = GetComponent<HorizontalLayoutGroup>().spacing;
        adjusted =5;
        
        
        

           
    }  
    

    private void Update()
    {
        handCount = transform.childCount;

        

        // foreach (Transform childCard in transform)
        // {
        //     GetComponentInChildren<AspectRatioFitter>().aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;
        // }

        

        
        

        //Debug.Log(handCount);
        
         

        
    }
    private void FixedUpdate()
    {
        AdjustSpread(handCount);
   
    }

    public void AdjustSpread(int hand)
    {
        if (transform.childCount == 5)
        {
            GetComponent<HorizontalLayoutGroup>().spacing = -162.3f;
            // GetComponent<HorizontalLayoutGroup>().padding.left = 1;
            // GetComponent<HorizontalLayoutGroup>().padding.right = 1;
            adjusted = 0;
        }
        if (hand > adjusted && transform.childCount > 5)
       {
            adjusted = hand;
            adjusted++;
            GetComponent<HorizontalLayoutGroup>().spacing += 20;
            
          
       }
    }
}
