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
        PlayerPrefs.Save();
    }

    public void BtnMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
        FindObjectOfType<AudioManager>().StopAllSound();
        FindObjectOfType<AudioManager>().PlaySound("MainMenuTheme");
        PlayerPrefs.Save();
        
    }

    
    public void BtnGameplayScene()
    {
        FindObjectOfType<AudioManager>().StopAllSound();
        SceneManager.LoadScene("Gameplay");
        FindObjectOfType<AudioManager>().PlaySound("GamePlayTheme");
        PlayerPrefs.Save();
        
    }

    public void BtnGameSetupScene()
    {
        FindObjectOfType<AudioManager>().StopAllSound();
        SceneManager.LoadScene("GameSetup");
        FindObjectOfType<AudioManager>().PlaySound("EmptyRoom");
        PlayerPrefs.Save();
        
    }

    
    public void BtnExit()
    {
        FindObjectOfType<AudioManager>().StopAllSound();
        FindObjectOfType<AudioManager>().PlaySound("Whoosh");
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void RestartGame()
    {
        
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene("Gameplay");
    }



}
