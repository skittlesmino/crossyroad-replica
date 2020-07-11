using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public GameObject player;
    float x;
    float z;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private LayerMask groundLayer;
    public BoxCollider boxCollider;
    bool isColliding;
    Vector3 endPos;
    Vector3 startPos;
    Vector3 velocity;
    float lerpTime;
    float currentLerpTime;
    public float perc = 1f;
    bool hasParent = false;
    bool firstInput;
    public bool justJump;
    public float groundDistance;
    public float gravity = 10f;
    float parentSpeed;
    Animator animPlayer;
    public bool check;
    public bool hasMoved = false;
    bool canAnim = false;
    float changedPos;
    bool outOfScreen = false;
    public AudioSource[] playerSounds;
    float elapsedTime;
    bool cameraStartedMoving = false;
    void Start()
    {
        animPlayer = player.GetComponent<Animator>();
        playerSounds = GameObject.Find("Chicken").GetComponents<AudioSource>();
        
    }

    void Update()
    {

        RaycastHit hit;
        check = Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), Vector3.down, out hit, groundDistance, groundLayer);
        //Debug.Log(hit.collider);

        if (perc == 1)
        {
            firstInput = false;
            
        }
        startPos = gameObject.transform.position;

        x = Input.GetAxis("w");
        z = Input.GetAxis("d");
        
        if (transform.parent != null)
            hasParent = true;
        else
            hasParent = false;
        if (!check && transform.position.y > 0.05f && !firstInput && !outOfScreen)
        {
            transform.Translate(0, -gravity * Time.deltaTime, 0);
        }
        else if (check && (transform.position.y < 0.75f)) transform.position = new Vector3(transform.position.x, 0.34f, transform.position.z);
        

        if (Physics.CheckSphere(transform.position + new Vector3(x, 0, z),0, layerMask)) isColliding = true;
        else isColliding = false;

        if (Input.GetButtonDown("d") && player.GetComponent<PlayerState>().isAlive && justJump == false && !isColliding && Time.time > elapsedTime)
        {
            if(cameraStartedMoving == false)
            {
                Camera.main.GetComponent<CameraFollowScript>().isMoving = true;
            }
            if (perc == 1)
            {
                lerpTime = 1;
                currentLerpTime = 0;
                firstInput = true;
                justJump = true;
                canAnim = true;
                playerSounds[Random.Range(1, 6)].Play();
            }
            elapsedTime = Time.time + 0.15f;
            endPos = new Vector3(Mathf.Round(transform.position.x - 0.5f) + 0.5f, transform.position.y, Mathf.Round(transform.position.z + z - 0.5f) + 0.5f);
        }
        else if(Input.GetButtonDown("w") && player.GetComponent<PlayerState>().isAlive && justJump == false && !isColliding && Time.time > elapsedTime)
        {
            if (cameraStartedMoving == false)
            {
                Camera.main.GetComponent<CameraFollowScript>().isMoving = true;
            }
            if (perc == 1)
            {
                lerpTime = 1;
                currentLerpTime = 0;
                firstInput = true;
                justJump = true;
                canAnim = true;
                playerSounds[Random.Range(1,6)].Play();
                
            }
            //if (!hasParent)
            elapsedTime = Time.time + 0.15f;
            endPos = new Vector3(Mathf.Round(transform.position.x + x - 0.5f) + 0.5f, transform.position.y, Mathf.Round(transform.position.z - 0.5f) + 0.5f);
            //else endPos = new Vector3(Mathf.Round(transform.position.x + x - 0.5f) + 0.5f, transform.position.y, transform.position.z);
        }

        if (firstInput == true) { 
            currentLerpTime += Time.deltaTime * 5;
            perc = currentLerpTime / lerpTime;
            gameObject.transform.position = Vector3.Lerp(startPos, endPos, perc);
            if (perc > 0.6) perc = 1;
            if (Mathf.Round(perc) == 1) justJump = false;   
        }
        
    }

    void LateUpdate()
    {
        if (Mathf.Abs(transform.position.z) > 12 && transform.parent != null)
        {
            transform.parent = null;
            transform.Translate(0, 5f, 0);
            outOfScreen = true;
        }

    }
}
