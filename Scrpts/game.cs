using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game : MonoBehaviour
{
    public string labelText = "Collect 4 items";
    public string shieldTest = "Inactive";
    public string bombTest = "Ready";
    public Texture t;
    public int maxItems = 4;
    public Material BoxTexture;
    public GameObject ice;
    private bool start;
    private int _itemsCollected = 0;
    private bool showWinScreen = false;
    private bool showLoseScreen = false;
    private bool gateState = true;
    private bool pause = false;
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
            if(_frost){
                ice.SetActive(true);
            }else{
                ice.SetActive(false);
            }
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
    void Update(){
        if(Input.GetKeyUp(KeyCode.Escape)){
            if(!pause){
                Time.timeScale = 0;
                pause=true;
            }else{
                Time.timeScale = 1f;
                pause=false;
            }
        }
    }
    void Restart(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
    void OnGUI(){
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" +
            _playerHealth);
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " +
            _itemsCollected);
        GUI.Box(new Rect(20, 80, 150, 25), "Shield " + shieldTest);
        GUI.Box(new Rect(20, 110, 150, 25), "Bomb " + bombTest);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height -
            50, 300, 50), labelText);
        if(pause){
            GUI.Box(new Rect(Screen.width/2 - 75, Screen.height/2 -50, 100, 25), "Paused");
            if(GUI.Button(new Rect(Screen.width/2 - 75, Screen.height/2 + 50, 100, 25), "Restart")){
                Restart();
            }
        }
        if(showWinScreen){
            if (GUI.Button(new Rect(Screen.width/2 - 100,
                Screen.height/2 - 50, 200, 100), "YOU WON!")){
                Restart();
            }
        }
        if(showLoseScreen){
            if (GUI.Button(new Rect(Screen.width/2 - 100,
                Screen.height/2 - 50, 200, 100), "YOU LOSE!")){
                Restart();
            }
        }
    }
}