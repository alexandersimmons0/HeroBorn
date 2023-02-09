using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
 public float onscreenDelay = 2f;
 
 void Start (){
    Destroy(this.gameObject, onscreenDelay);
 }
}
