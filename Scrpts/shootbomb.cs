using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootbomb : MonoBehaviour
{
 private SphereCollider _col;
 private Rigidbody _rb;
 private game _gameManager;
 public float distanceToGround = 0.1f;
 public float onscreenDelay = 0.5f;
 public LayerMask groundLayer;
 public Renderer rend;

 void Start (){
    _col = GetComponent<SphereCollider>();
    _rb = GetComponent<Rigidbody>();
   // _gameManager = GameObject.Find("GameManager").GetComponent<game>();
    rend = GameObject.Find("explosion").GetComponent<Renderer>();
    rend.enabled = false;
 }
 void FixedUpdate(){
    
 }
 void OnCollisionEnter(Collision collision){
    _rb.velocity = Vector3.zero;
    _rb.angularVelocity = Vector3.zero;
    rend.enabled = true;
    Destroy(this.gameObject, onscreenDelay);
   // _gameManager.Throw = true;
 }
}
