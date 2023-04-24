using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class game : MonoBehaviour
{
    public string labelText = "Collect 4 items";
    public string shieldTest = "Inactive";
    public string bombTest = "Ready";
    public Texture t;
    public int maxItems = 4;
    public Material BoxTexture;
    public GameObject exitToMenu;
    public GameObject lose;
    public GameObject masterSlider;
    public GameObject musicSlider;
    public GameObject sfxSlider;
    private bool start;
    private int _itemsCollected = 0;
    private bool showWinScreen = false;
    private bool showLoseScreen = false;
    private bool gateState = true;
    private bool pause = false;
    public bool Paused{
        get{return pause;}
        set{pause=value;}
    }
    public bool Gate{
        get{return gateState;}
        set{gateState = value;}
    }
    private bool bossFight = false;
    public bool Fight{
        get{return bossFight;}
        set{bossFight = value;}
    }
    private bool _shield = false;
    public bool Shield{
        get{return _shield;}
        set{
            _shield = value;
            if(_shield){
                shieldTest = "Active";
                Debug.Log("Shield maybe");
            }else{
                shieldTest = "Inactive";
            }
        }
    }
    private bool _bomb = true;
    public bool Throw{
        get{return _bomb;}
        set{
            _bomb = value;
            if(_bomb){
                bombTest = "is Ready";
            }else{
                bombTest = "Consumed";
            }
        }
    }
    private bool _frost = true;
    public bool Frost{
        get{return _frost;}
        set{
            _frost = value;
        }
    }
    public int Items{
        get{ return _itemsCollected;}
        set{
            _itemsCollected = value;
            if(_itemsCollected >= maxItems){
                labelText = "Gate is unlocked";
                Gate = false;
                //showWinScreen = true;
                //Time.timeScale = 0f;
            }else{
                labelText = "Item found. " + (maxItems - _itemsCollected) + " to go";
            }
            Debug.LogFormat("Items: {0}", _itemsCollected);
        }
    }
    private int _playerHealth = 2;
    public int HP{
        get{ return _playerHealth;}
        set{
            _playerHealth = value;
            Debug.LogFormat("Lives: {0}", _playerHealth);
            if(_playerHealth <= 0){
                labelText = "You died";
                showLoseScreen = true;
                Time.timeScale = 0;
            }
        }
    }
    void Start(){
        exitToMenu.SetActive(false);
        lose.SetActive(false);
        masterSlider.SetActive(false);
        musicSlider.SetActive(false);
        sfxSlider.SetActive(false);
        pause = false;
        Time.timeScale = 1f;
    }
    void Update(){
        if(Input.GetKeyUp(KeyCode.Escape)&&!showLoseScreen){
            if(!pause){
                Time.timeScale = 0;
                pause=true;
                exitToMenu.SetActive(true);
                masterSlider.SetActive(true);
                musicSlider.SetActive(true);
                sfxSlider.SetActive(true);
            }else{
                Time.timeScale = 1f;
                pause=false;
                exitToMenu.SetActive(false);
                masterSlider.SetActive(false);
                musicSlider.SetActive(false);
                sfxSlider.SetActive(false);
            }
        }
        if(showLoseScreen){
            exitToMenu.SetActive(true);
            lose.SetActive(true);
            masterSlider.SetActive(true);
            musicSlider.SetActive(true);
            sfxSlider.SetActive(true);
            Time.timeScale = 0;
        }
    }
    void OnGUI(){
        if(showWinScreen){
            if (GUI.Button(new Rect(Screen.width/2 - 100,
                Screen.height/2 - 50, 200, 100), "YOU WON!")){
                Utilities.RestartLevel();
            }
        }
    }
}