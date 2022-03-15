using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class Selection : MonoBehaviour
{
   public static Selection instance;
   [SerializeField] private TMP_Text _selectedCharacter;
   [SerializeField] private TMP_Text _selectedScenario;
   [SerializeField] private TMP_Text _selectedMansion;

   [Space]
   [SerializeField] private CharacterCollection _charactersDB;
   [SerializeField] public List<CharacterClass> ListOfCharacters;
   [Space]
   [SerializeField] private ScenarioCollection _scenariosDB;
   [SerializeField] public List<ResourceCollectionBase> ListOfScenarios;
   [Space]
   [SerializeField] public MansionCollectionDatabase _mansionsDB;
   [SerializeField] public List<MansionDatabaseClass> ListOfMansions;
   [Space]
   public int ChosenCharacter;
   public int ChosenScenario;
   public int ChosenMansion;

   

   
   

   private void Awake()
   {
      if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
   }
   private void Start()
   {

      ListOfCharacters = new List<CharacterClass>(_charactersDB.characterCollection);
      ListOfScenarios = new List<ResourceCollectionBase>(_scenariosDB.thisScenarioCollection);
      ListOfMansions = new List<MansionDatabaseClass>(_mansionsDB.thisMansionCollection);

      var name = ListOfCharacters[0].name;    
      _selectedCharacter.text = name.Substring(name.IndexOf(" "));

      _selectedScenario.text = ListOfScenarios[0].name;
      _selectedMansion.text = ListOfMansions[0].name;
      SetIntPlayerPrefs("Character", 0);
      SetIntPlayerPrefs("Scenario", 0);
      SetIntPlayerPrefs("Mansion", 0);
      
   }

   int index;
   public void NextCharacter()
   {
      index++;
      if ( (index+1) > ListOfCharacters.Count)
      {  
         index = 0;
         
      }
      
      var name = ListOfCharacters[index].name;    
      _selectedCharacter.text = name.Substring(name.IndexOf(" "));
      SetIntPlayerPrefs("Character", index);
   }

   public void PreviousCharacter()
   {
      index--;
      if (index < 0)
      {  
         index = ListOfCharacters.Count-1;
         
      }
      var name = ListOfCharacters[index].name;
      
      _selectedCharacter.text = name.Substring(name.IndexOf(" "));

      SetIntPlayerPrefs("Character", index);

   }
    public void PreviousScenario()
   {
      index--;
      if (index < 0)
      {  
         index = ListOfScenarios.Count-1;
         
      }
      var name = ListOfScenarios[index].name;    
      _selectedScenario.text = name;
      SetIntPlayerPrefs("Scenario", index);

   }

    public void NextScenario()
   {
      index++;
      if ( (index+1) > ListOfScenarios.Count)
      {  
         index = 0;
         
      }
      var name = ListOfScenarios[index].name;    
      _selectedScenario.text = name;

      SetIntPlayerPrefs("Scenario", index);

   }


   public void NextMansion()
   {
      index++;
      if ( (index+1) > ListOfMansions.Count)
      {  
         index = 0;
         
      }
      var name = ListOfMansions[index].name;    
      _selectedMansion.text = name;
      
      SetIntPlayerPrefs("Mansion", index);
   }

    public void PreviousMansion()
   {
      index--;
      if (index < 0)
      {  
         index = ListOfMansions.Count-1;
         
      }
      var name = ListOfMansions[index].name;    
      _selectedMansion.text = name;

      SetIntPlayerPrefs("Mansion", index);
   }



   public void RandomGameplaySetup()
   {
      RandomMansion();
      RandomCharacter();
      RandomScenario();
   }

   private void RandomMansion()
   {
      var range = Random.Range(0, ListOfMansions.Count);
      SetIntPlayerPrefs("Mansion", range);
      _selectedMansion.text = ListOfMansions[range].name;
   }
   private void RandomCharacter()
   {
      var range = Random.Range(0, ListOfCharacters.Count);

      var rand = ListOfCharacters[range].name; 
      SetIntPlayerPrefs("Character", range);   
      _selectedCharacter.text = rand.Substring(rand.IndexOf(" "));
   }

   private void RandomScenario()
   {
      var range = Random.Range(0, ListOfScenarios.Count);
      SetIntPlayerPrefs("Scenario", range);
      _selectedScenario.text = ListOfScenarios[range].name;
   }

   // public void SaveSetup()
   // {
   //    PlayerPrefs.SetInt("Character", ChosenCharacter);
   //    PlayerPrefs.SetInt("Scenario", ChosenScenario);
   //    PlayerPrefs.SetInt("Mansion", ChosenMansion);
      
   // }

   private void SetIntPlayerPrefs(string name, int index)
   {
      PlayerPrefs.SetInt(name, index);
      PlayerPrefs.Save();
   }
     

}
