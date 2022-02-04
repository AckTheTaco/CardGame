using UnityEngine;

[System.Serializable]
public class ACardClass 
{
    public string cardName;
    public string cardType;
    public string cardID;
    public string cardEdition;

    public ACardClass()
    {

    }

    public ACardClass(string CardName, string CardType, string CardID, string CardEdition)
    {
        cardName = CardName;
        cardType = CardType;
        cardID = CardID;
        cardEdition = CardEdition;
    }
}
