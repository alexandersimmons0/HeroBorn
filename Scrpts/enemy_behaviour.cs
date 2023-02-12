using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_behaviour : MonoBehaviour
{
    public Transform player;
    public Transform patrolRoute;
    public List<Transform> locations;
    private game _gameManager;
    private int locationIndex = 0;
    private NavMeshAgent agent;
    private int _lives = 3;
    public int enemyLives{
        get{ return _lives;}
        set{
            _lives = value;
            if(_lives <= 0){
                Destroy(this.gameObject);
                Debug.Log("Enemy Down");
            }
        }
    }
    void Start(){
        agent = GetComponent<NavMeshAgent>();
        _gameManager = GameObject.Find("GameManager").GetComponent<game>();
        player = GameObject.Find("Player").transform;
        InitializePatrolRoute();
        MoveToNextLocation();
    }
    void Update(){
        if(agent.remainingDistance<0.2f&&!agent.pathPending){
            MoveToNextLocation();
        }
    }
    void InitializePatrolRoute(){
        foreach(Transform child in patrolRoute){
            locations.Add(child);
        }
    }
    void MoveToNextLocation(){
        if(locations.Count == 0)
            return;
        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;
    }
    void OnTriggerEnter(Collider other){
        if(other.name == "Player"){
            agent.destination = player.position;
            Debug.Log("Player detected - Attack");
        }else if(other.name == "shield?"&&(_gameManager.Shield)){
            Debug.Log("hit shield");
            Destroy(this.gameObject);
            _gameManager.Shield = false;
        }else if(other.name == "explosion"){
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "bullet(Clone)"){
            enemyLives -= 1;
        }
    }
    void OnTriggerExit(Collider other){
        if(other.name == "Player"){
            Debug.Log("out of range. patrol");
        }
    }
}
