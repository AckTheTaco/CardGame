using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuffler
{
   public static void ShuffleDeck(List<CompleteCard> thisDeck)// static can be called from anywhere. assign the "Shuffle" method in unity to a Button. Choose the deck object to shuffle does the shuffle 5 times on the deck that is passed through
    {
        List<CompleteCard> mCon = new List<CompleteCard>();
        mCon.Add(thisDeck[0]);
        //mCon.Clear();
        
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < thisDeck.Count; j++)
            {
                
                mCon[0] = thisDeck[j];
                int randomIndex = Random.Range(j, thisDeck.Count);
                thisDeck[j] = thisDeck[randomIndex];
                thisDeck[randomIndex] = mCon[0];

            }
            //return thisDeck;
            Debug.Log("The Deck is now Shuffled");
            
        }
    }
}
