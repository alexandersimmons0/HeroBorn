using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.name == "Player"){
            Debug.Log("Player detected - Attack");
        }
    }
    void OnTriggerExit(Collider other){
        if(other.name == "Player"){
            Debug.Log("out of range. patrol");
        }
    }
}
