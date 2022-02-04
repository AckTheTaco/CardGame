using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BtnClick : MonoBehaviour
{
    public GameObject goScreen;
    public void BtnOptionsScene()
    {
        SceneManager.LoadScene("Options");
    }

    public void BtnMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
    public void BtnGameplayScene()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void BtnGameSetupScene()
    {
        SceneManager.LoadScene("GameSetup");
    }

    
    public void BtnExit()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        goScreen.SetActive(false);
        SceneManager.LoadScene("Gameplay");
    }



}
