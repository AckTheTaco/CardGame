using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckToHand : MonoBehaviour
{
    
    public GameObject PlayerHand;
    public GameObject PlayerCardInHand;

    public List<ACardClass> PlayerDeck;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerDeck = PlayerDEck.staticPlayerDeck;
    }

    // Update is called once per frame
    void Update()
    {
        // PlayerCardInHand.GetComponent<UpdateCardUI>().cardNameText.text = PlayerDeck[0].cardName;
        // PlayerCardInHand.GetComponent<UpdateCardUI>().cardBack = false; //SCIENTIFICCIIC BRO this flips the card face up of faceDown
        PlayerHand = GameObject.Find("PlayerHandHolder");
        PlayerCardInHand.transform.SetParent(PlayerHand.transform);
        PlayerCardInHand.transform.localScale = Vector3.one;
        PlayerCardInHand.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        PlayerCardInHand.transform.eulerAngles = new Vector3(25,0,0);
    }
  
    
}
