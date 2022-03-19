
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject _parentToReturnTo = null;
    public string listName;

    public string oldList;

    public string homeList;
    string destinationHolder;

    private List<RaycastResult> _raycastAllHits = new List<RaycastResult>();

    [SerializeField]private bool _isDraggable;
    [SerializeField] public bool IsSelected;

    [SerializeField] private CompleteCard _thisCard;
    
    private Dictionary<string, List<CompleteCard>> _listDictionary;

    
    private void Start()
    {
        if (this.transform.parent.gameObject.name == "PlayerHandHolder")
        {
            _isDraggable = true;
        }
        else
        {
            _isDraggable = false;
        }

        if(IsWeapon())
            _thisCard = GetComponent<WeaponCardUI>().refCard;
        else if (IsAction())
            _thisCard = GetComponent<ActionCardUI>().refCard;
        else    
            _thisCard = GetComponent<ItemCardUI>().refCard;
        

       

        _listDictionary = CardHandler.instance.listDictionary;

    }
    void Update()
    {
        /*
        * This needs to be activated to stop unautherorized drag-n-drop from the resource area and playerFeild
        */
        if (_isDraggable != true)
        {
            GetComponent<Drag>().enabled = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        homeList = gameObject.transform.parent.name;

        oldList = homeList;

        

        _parentToReturnTo = this.transform.parent.gameObject;
        this.transform.SetParent(this.transform.root);

        if (_listDictionary.ContainsKey(homeList))
        {
            _listDictionary[homeList].Remove(_thisCard);
        }
        else
        {
            print($"{_thisCard} was not found to be in a list called {homeList}");
        }
        
        Debug.Log($"{this} will return to {_parentToReturnTo}");
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        this.GetComponent<CanvasGroup>().alpha = .6f;

        
    }
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        EventSystem.current.RaycastAll(eventData, _raycastAllHits);
        
        for (int i = 0; i < _raycastAllHits.Count; i++)
        {
            var hitName = _raycastAllHits[i].gameObject.name;
            
            if (IsWeapon() && hitName == "WeaponHolder")
            {
                
                if (_thisCard.AmmoCost == 0 || GameManager.instance.Ammo >= _thisCard.AmmoCost)
                {
                    _parentToReturnTo = _raycastAllHits[i].gameObject;

                    AspectSetter( _parentToReturnTo.name);
                    
                    this.transform.SetParent(_parentToReturnTo.transform);
                    
                    listName = gameObject.transform.parent.name;
                    homeList = listName;
                    
                    _listDictionary[homeList].Add(_thisCard);
                    
                    PlayerDamage(_thisCard);

                    if (_listDictionary[oldList].Count > 0 && oldList != "PlayerHandHolder")
                        UiHandler.instance.CreateCardUI(_listDictionary[oldList][0], GameObject.Find(oldList).transform, oldList);
                    else
                    {
                        print($"No cards at location or card came from hand");
                    }
                }
                else
                {
                    Debug.Log($"{_thisCard} need more Ammo than you have produced");
                    this.transform.SetParent(_parentToReturnTo.transform);
                }

               
                
                
               
            }
            else if (IsAction() && hitName == "ActionHolder")
            {
                _parentToReturnTo = _raycastAllHits[i].gameObject;
                this.transform.SetParent(_parentToReturnTo.transform);
                AspectSetter( _parentToReturnTo.name);

                listName = gameObject.transform.parent.name;
                homeList = listName;

               
                

                _listDictionary[homeList].Add(_thisCard);

                if (_listDictionary[oldList].Count > 0 && oldList != "PlayerHandHolder")
                    UiHandler.instance.CreateCardUI(_listDictionary[oldList][0], GameObject.Find(oldList).transform, oldList);
                else
                {
                    print($"No cards at location");
                    return;
                }
                
                
            }
            else if (IsItem() && hitName == "ItemHolder")
            {
                _parentToReturnTo = _raycastAllHits[i].gameObject;
                this.transform.SetParent(_parentToReturnTo.transform);
                AspectSetter( _parentToReturnTo.name);

                

                listName = gameObject.transform.parent.name;
                homeList = listName;

               
                
                _listDictionary[homeList].Add(_thisCard);
                UpdateAmmoAndGold(_thisCard);

                if (_listDictionary[oldList].Count > 0 && oldList != "PlayerHandHolder")
                    UiHandler.instance.CreateCardUI(_listDictionary[oldList][0], GameObject.Find(oldList).transform, oldList);
                else
                {
                    print($"No cards at location");
                    return;
                }
                
                
                
            }
            else
            {
                Debug.Log($"{this.name} has returned to {_parentToReturnTo.ToString()}");
                this.transform.SetParent(_parentToReturnTo.transform);
                AspectSetter(_parentToReturnTo.name);
            }
        }

        

        
    }

    bool IsWeapon()
    {
        if (name.Contains("WE-"))
            return true;
        else
            return false;
        
    }

    bool IsAction()
    {
        if (name.Contains("AC-"))
            return true;
        else 
            return false;
    }

    bool IsItem()
    {
        if ((name.Contains("IT-") || name.Contains("AM-")))
            return true;
        else
            return false;
    }

    void AspectSetter(string parentName)
    {
        if (parentName == "PlayerHandHolder" )
        {     
            GetComponent<AspectRatioFitter>().aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;
        }
        else
        {
            GetComponent<AspectRatioFitter>().aspectMode = AspectRatioFitter.AspectMode.WidthControlsHeight;
        }
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
        this.GetComponent<CanvasGroup>().alpha = 1f;
    }

    void UpdateAmmoAndGold(CompleteCard thisCard)
    {
        GameManager.instance.Ammo += thisCard.AmmoGiven;
        GameManager.instance.Gold += thisCard.GoldGiven;
    }

    void PlayerDamage(CompleteCard thisCard)
    {
        GameManager.instance.PlayerDamage += thisCard.Damage;
    }
}
