using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    private SphereCollider _col;
    private Rigidbody _rb;
    void Start(){
        _col = GetComponent<SphereCollider>();
        _rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision){
        Destroy(this.gameObject);
    }
}
