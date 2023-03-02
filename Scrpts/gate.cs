using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour
{
    private game gameManager;
    private BoxCollider _col;
    private Renderer rend;
    void Start()
    {
        _col = GetComponent<BoxCollider>();
        rend = GetComponent<MeshRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<game>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.Gate){
            _col.enabled = true;
            rend.enabled = true;
        }else{
            _col.enabled = false;
            rend.enabled = false;
        }
    }
}
