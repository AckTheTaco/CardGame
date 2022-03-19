using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnMouseCLick : MonoBehaviour, IPointerClickHandler //, IPointerDownHandler, IPointerUpHandler
{

    Drag card;
    public Image selctedFrame;
    private List<CompleteCard> _selectedCard;

    private void Awake()
    {
        card = this.GetComponent<Drag>();
        _selectedCard = CardHandler.instance.listDictionary["SelectedCards"];
    }

    private void Update()
    {
        
        if (card.IsSelected == true)
            selctedFrame.GetComponent<Image>().color = Color.cyan;
        else
        {
            selctedFrame.GetComponent<Image>().color = Color.clear;
        }

        





        
        
        

       
    }

    // private void FixedUpdate()
    // {
    //     if ((_selectedCard.Contains(this.GetComponent<WeaponCardUI>().refCard) ||_selectedCard.Contains(this.GetComponent<ItemCardUI>().refCard) || _selectedCard.Contains(this.GetComponent<ActionCardUI>().refCard)))
    //     {
    //         print($"{this.name} is in the selected cards list");
    //     }
    //     else
    //         return;
    // }
    

    
    public void OnPointerClick(PointerEventData eventData)
    {
        
        card.IsSelected = !card.IsSelected;

        if (card.IsSelected == true)
        {
            
            switch(name)
            {
                case string a when a.Contains("WE-"):
                    _selectedCard.Add(this.GetComponent<WeaponCardUI>().refCard);
                    break;
                case string b when b.Contains("AM-") || b.Contains("IT-"):
                    _selectedCard.Add(this.GetComponent<ItemCardUI>().refCard);
                    break;
                case string c when c.Contains("AC-"):
                    _selectedCard.Add(this.GetComponent<ActionCardUI>().refCard);
                    break;
                default:   
                    print("Card not found");
                break;
            }
            
            
            print($"You Selected {this.name} and there are now {_selectedCard.Count} in the 'SelectedCards' list");
        }
        else
        {
            
            
             switch(name)
             {
                case string a when a.Contains("WE-"):
                    _selectedCard.Remove(this.GetComponent<WeaponCardUI>().refCard);
                    break;
                case string b when b.Contains("AM-") || b.Contains("IT-"):
                    _selectedCard.Remove(this.GetComponent<ItemCardUI>().refCard);
                    break;
                case string c when c.Contains("AC-"):
                    _selectedCard.Remove(this.GetComponent<ActionCardUI>().refCard);
                    break;
                default:   
                    print("Card not found");
                break;
            }
            
            print($"You deselected {this.name} and there are now {_selectedCard.Count} in the 'SelectedCards' list");

        }

        
        
        
        
    }

    // public void OnPointerDown(PointerEventData eventData)
    // {
    //     print($"You pointerDown {this.name}");
    // }

    // public void OnPointerUp(PointerEventData eventData)
    // {
    //     print($"You pointerUp {this.name}");
    // }

}
