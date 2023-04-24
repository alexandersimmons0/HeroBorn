using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    public Button button;
    public string sceneName;
    void Start(){
        button.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick(){
        SceneManager.LoadScene(sceneName);
    }
}
