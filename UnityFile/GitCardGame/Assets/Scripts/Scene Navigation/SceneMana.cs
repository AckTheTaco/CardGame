using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneMana : MonoBehaviour
{



    public GameObject gameOverScreen;



    

    
    public float waitTime;

    private void Awake()
    {
       
        
    }
    private void Update()
    {
        
    }

  
    public void BtnOptionsScene()
    {
        FindObjectOfType<AudioManager>().StopAllSound();
        SceneManager.LoadScene("Options");
        FindObjectOfType<AudioManager>().PlaySound("Campfire");
    }

    public void BtnMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
        FindObjectOfType<AudioManager>().StopAllSound();
        FindObjectOfType<AudioManager>().PlaySound("MainMenuTheme");
        
    }

    
    public void BtnGameplayScene()
    {
        FindObjectOfType<AudioManager>().StopAllSound();
        SceneManager.LoadScene("Gameplay");
        FindObjectOfType<AudioManager>().PlaySound("GamePlayTheme");
        
    }

    public void BtnGameSetupScene()
    {
        FindObjectOfType<AudioManager>().StopAllSound();
        SceneManager.LoadScene("GameSetup");
        FindObjectOfType<AudioManager>().PlaySound("EmptyRoom");
        
    }

    
    public void BtnExit()
    {
        FindObjectOfType<AudioManager>().StopAllSound();
        FindObjectOfType<AudioManager>().PlaySound("Whoosh");
        Application.Quit();
    }

    public void RestartGame()
    {
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene("Gameplay");
    }



}
