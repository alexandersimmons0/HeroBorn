using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float rotation = 75f;
    public float jump = 5f;
    public float distanceToGround = 0.1f;
    public float fireRate = 50.0f;
    private float nextFire = 0.0f;
    public float fireRateF = 10.0f;
    private float nextFireF = 0.0f;
    public GameObject bullet;
    public float bulletSpeed = 100f;
    public GameObject bomb;
    public float bombSpeed = 25f;
    public GameObject frost;
    public float frostSpeed = 35f;
    public LayerMask groundLayer;
    private float vInput;
    private float hInput;
    private Rigidbody _rb;
    private game _gameManager;
    private CapsuleCollider _col;
    public bool magicBox = false;

    void Start(){
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("GameManager").GetComponent<game>();
    }
    void Update()
    {
        vInput = Input.GetAxis("Vertical") * speed;
        hInput = Input.GetAxis("Horizontal") * rotation;
        /*
        this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);    */
    }
    void FixedUpdate(){
        if(Input.GetMouseButtonDown(0)){
            GameObject newBullet = Instantiate(bullet,
            this.transform.position + new Vector3(1,0,0),
            this.transform.rotation) as GameObject;
            Rigidbody bulletRB =
                newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
        }
        if(Time.time>nextFire){
            _gameManager.Throw = true;
        }
        if(Input.GetKey(KeyCode.G)&&Time.time>nextFire){
            nextFire = Time.time + fireRate;
            GameObject newBomb = Instantiate(bomb,
            this.transform.position + new Vector3(-1,0,0),
            this.transform.rotation) as GameObject;
            Rigidbody bombRB =
                newBomb.GetComponent<Rigidbody>();
            bombRB.velocity = this.transform.forward * bombSpeed;
            _gameManager.Throw = false;
        }
        if(Time.time>nextFireF){
            _gameManager.Frost = true;
        }
        if(Input.GetKey(KeyCode.F)&&Time.time>nextFireF){
            nextFireF = Time.time + fireRateF;
            GameObject newFrost = Instantiate(frost,
            this.transform.position + new Vector3(0,0,-1),
             this.transform.rotation) as GameObject;
            Rigidbody frostRB = newFrost.GetComponent<Rigidbody>();
            frostRB.velocity = this.transform.forward * frostSpeed;
            _gameManager.Frost = false;
        }
        if(IsGrounded() && Input.GetKey(KeyCode.Space)){
            _rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.deltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);
    }
    private bool IsGrounded(){
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x,
        _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center,
        capsuleBottom, distanceToGround, groundLayer,
        QueryTriggerInteraction.Ignore);
        return grounded;
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Enemy" ||
            collision.gameObject.name == "Enemy1"||
            collision.gameObject.name == "Enemy2"||
            collision.gameObject.name == "Enemy3"||
            collision.gameObject.name == "Enemy4"||
            collision.gameObject.name == "Enemy5")
            _gameManager.HP -= 1;
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "close"){
            //if(_gameManager.Gate!=true){
                _gameManager.Gate = true;
                _gameManager.Fight = true;
                Debug.Log("gate closed");
            //}
        }
    }
}
