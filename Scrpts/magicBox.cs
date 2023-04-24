using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class magicBox : MonoBehaviour
{
    private game gameManager;
    private AudioSource sound;
    private Renderer rend;
    private Renderer purpleRend;
    private Collider col;
    void Start(){   
    gameManager = GameObject.Find("GameManager").GetComponent<game>();
    sound = GetComponent<AudioSource>();
    rend = GetComponent<Renderer>();
    purpleRend = GameObject.Find("purpleCube").GetComponent<Renderer>();
    col = GetComponent<SphereCollider>();
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Player"){
            sound.Play();
            rend.enabled = false;
            purpleRend.enabled = false;
            col.enabled = false;
            gameManager.Shield = true;
        }
    }
}
