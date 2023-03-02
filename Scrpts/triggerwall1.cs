using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerwall1 : MonoBehaviour
{
    private game gameManager;
    private Renderer rend;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<game>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        if(other.name == "Player"){

        }
    }
}
