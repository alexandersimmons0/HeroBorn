using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class health : MonoBehaviour
{
    private game gameManager;
    private AudioSource sound;
    private Renderer rend;
    private Collider col;
    void Start(){   
    gameManager = GameObject.Find("GameManager").GetComponent<game>();
    sound = GetComponent<AudioSource>();
    rend = GameObject.Find("pCylinder3").GetComponent<Renderer>();
    col = GetComponent<CapsuleCollider>();
    rend.enabled = true;
    col.enabled = true;
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Player"){
            sound.Play();
            rend.enabled = false;
            col.enabled = false;
            gameManager.HP++;
        }
    }
}
