using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utilities
{
    public static int playerDeaths = 0;
    public static void RestartLevel(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
    public static bool RestartLevel(int sceneIndex){
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1.0f;
        return true;
    }
}
