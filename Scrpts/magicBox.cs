using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicBox : MonoBehaviour
{
    private game gameManager;
    void Start(){   
    gameManager = GameObject.Find("GameManager").GetComponent<game>();
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Player"){
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Item Collected");
            //gameManager.Items += 1;
            gameManager.Shield = true;
        }
    }
}
