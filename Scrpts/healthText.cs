using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthText : MonoBehaviour
{
    public Text healthS;
    public Text shieldS;
    public Text iceS;
    public Text itemS;
    private game _gameManager;
    void Start(){
        _gameManager = GameObject.Find("GameManager").GetComponent<game>();
    }
    void Update(){
        healthS.text="Health is " + _gameManager.HP;
        itemS.text="Items: " + _gameManager.Items;
        if(_gameManager.Shield){
            shieldS.text="Shield Active";
        }else if(!_gameManager.Shield){
            shieldS.text="Shield Inactive";
        }
        if(_gameManager.Frost){
            iceS.text="Shot Ready";
        }else if(!_gameManager.Frost){
            iceS.text="Shot Loading";
        }
    }
}
