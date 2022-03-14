using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class Selection : MonoBehaviour
{
   [SerializeField] private TMP_Text _selectedCharacter;
   [SerializeField] private TMP_Text _selectedScenario;
   [SerializeField] private TMP_Text _selectedMansion;

   [Space]
   [SerializeField] private CharacterCollection _charactersDB;
   [SerializeField] private List<CharacterClass> _characterList;
   [Space]
   [SerializeField] private ScenarioCollection _scenariosDB;
   [SerializeField] private List<ResourceCollectionBase> _scenarioList;
   [Space]
   [SerializeField] private MansionCollectionDatabase _mansionsDB;
   [SerializeField] private List<MansionDatabaseClass> _mansionList;

   

   
   

   private void Awake()
   {
      
   }
   private void Start()
   {
      _characterList = new List<CharacterClass>(_charactersDB.characterCollection);
      _scenarioList = new List<ResourceCollectionBase>(_scenariosDB.thisScenarioCollection);
      _mansionList = new List<MansionDatabaseClass>(_mansionsDB.thisMansionCollection);

      var name = _characterList[0].name;    
      _selectedCharacter.text = name.Substring(name.IndexOf(" "));

      _selectedScenario.text = _scenarioList[0].name;
      _selectedMansion.text = _mansionList[0].name;
   }

   int index;
   public void NextCharacter()
   {
      index++;
      if ( (index+1) > _characterList.Count)
      {  
         index = 0;
         
      }
      var name = _characterList[index].name;    
      _selectedCharacter.text = name.Substring(name.IndexOf(" "));

   }

   public void PreviousCharacter()
   {
      index--;
      if (index < 0)
      {  
         index = _characterList.Count-1;
         
      }
      var name = _characterList[index].name;    
      _selectedCharacter.text = name.Substring(name.IndexOf(" "));

   }
    public void PreviousScenario()
   {
      index--;
      if (index < 0)
      {  
         index = _scenarioList.Count-1;
         
      }
      var name = _scenarioList[index].name;    
      _selectedScenario.text = name;

   }

    public void NextScenario()
   {
      index++;
      if ( (index+1) > _scenarioList.Count)
      {  
         index = 0;
         
      }
      var name = _scenarioList[index].name;    
      _selectedScenario.text = name;

   }


   public void NextMansion()
   {
      index++;
      if ( (index+1) > _mansionList.Count)
      {  
         index = 0;
         
      }
      var name = _mansionList[index].name;    
      _selectedMansion.text = name;

   }

    public void PreviousMansion()
   {
      index--;
      if (index < 0)
      {  
         index = _mansionList.Count-1;
         
      }
      var name = _mansionList[index].name;    
      _selectedMansion.text = name;

   }





}
