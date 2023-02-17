using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_behavior : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 0.5f, -2.6f);
    public Vector3 camOffset1 = new Vector3(0f, 1.2f, -2.6f);
    private Transform target;
    private Transform target1;
    private float fireRate = 0.5f;
    private float nextFire = 0.0f;
    private bool cam = false;
    void Start(){
        target = GameObject.Find("cameraPoint").transform;
        target1 = GameObject.Find("Player").transform;

    }
    void FixedUpdate(){
        if(Input.GetKey(KeyCode.P)&&Time.time>nextFire){
            nextFire = Time.time + fireRate;
            if(cam==false){
                cam = true;
            }else{
                cam = false;
            }
        }
       /* }else if(Input.GetKey(KeyCode.O)){
            cam = false;
        }*/
    }
    void LateUpdate()
    {
        if(cam){
            this.transform.position = target.TransformPoint(camOffset);
            this.transform.LookAt(target);
        }else{
            this.transform.position = target1.TransformPoint(camOffset1);
            this.transform.LookAt(target1);
        }
    }
}
