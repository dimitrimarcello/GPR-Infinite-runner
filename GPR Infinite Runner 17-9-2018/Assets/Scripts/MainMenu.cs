﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
    public void RetryGame(string sceneName)
    {

        //SceneManager.UnloadSceneAsync(sceneName);
        //SceneManager.UnloadSceneAsync("GameOverScreen");
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

}
