using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public bool isYourTurn;
    public int yourTurn;

    [Space]

    public int isOpponetTurn;
    public TMP_Text turnText;


    public int MaxTurnCount;
    public int currentTurnCount;
    public TMP_Text turnCountText;

    public GameObject gameOverScreen;

    public static bool startTurn;

    [Space]
    public GameObject DeckToHand;





    // Start is called before the first frame update
    void Start()
    {
        isYourTurn = true;
        yourTurn = 1;
        isOpponetTurn = 0;

        MaxTurnCount = 15;
        currentTurnCount = 1;

        startTurn = false;

        

    }

    // Update is called once per frame
    void Update()
    {
        if (isYourTurn == true)
            turnText.text = "your Turn";
        else    
        {
            turnText.text = "Opponet Turn";
        }
            
        
        turnCountText.text = currentTurnCount + " / " + MaxTurnCount;
    }

    public void EndYourTurn()
    {
        isYourTurn = false;
        isOpponetTurn += 1;

    }

    public void EndOpponetTurn()
    {
        isYourTurn = true;
        if (currentTurnCount + 1 > MaxTurnCount)
            gameOverScreen.SetActive(true);
        else
        {
            currentTurnCount += 1;
        }

        Instantiate(DeckToHand, transform.position, transform.rotation);
    }
}
