using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    private Transform player;
    private game _gameManager;
    private Renderer rend;
    private float shotSpeed = 30f;
    private float fireRate = 20.0f;
    private float nextFire = 0.0f;
    public GameObject bossBullet;
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        player = GameObject.Find("Player").transform;
        _gameManager = GameObject.Find("GameManager").GetComponent<game>();
        rend.enabled = false;
    }


    void Update()
    {
        this.transform.LookAt(player);
        if(_gameManager.Fight){
            rend.enabled=true;
            if(Time.time>nextFire){
                nextFire = Time.time + fireRate;
                GameObject newShot = Instantiate(bossBullet,
                this.transform.position + new Vector3(0,5,0),
                this.transform.rotation) as GameObject;
                Rigidbody newShotRB = newShot.GetComponent<Rigidbody>();
                newShot.transform.LookAt(player);
                newShotRB.velocity = this.transform.forward * shotSpeed;
            }
        }
    }
}
