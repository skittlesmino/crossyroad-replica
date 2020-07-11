using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public GameObject target;
    public GameObject playerBody;
    public GameObject tileInfo;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private float oldX;
    Vector3 smoothedPosition;
    Rigidbody rb;
    public bool isMoving = false;
    bool isAlive;
    bool hasTransitioned = false;
    Vector3 lastPos;
    Vector3 transitionedPos;

    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        transform.position = target.transform.position + offset;
        
    }

    void FixedUpdate()
    {
        if (target != null)
            isAlive = playerBody.GetComponent<PlayerState>().isAlive;
        if (isAlive)
        {


            smoothedPosition = Vector3.Lerp(transform.position, target.transform.position + offset, smoothSpeed);

            if (smoothedPosition.x >= transform.position.x)
            {
                //if(Mathf.Abs(target.transform.position.z) < 2.6) 
                if (Mathf.Abs(target.transform.position.z) > 2.6)
                {
                    transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
                }
                else
                {
                    transform.position = smoothedPosition;
                }
                
            }
            else
            { 
                if (Mathf.Abs(target.transform.position.z) > 2.6)
                {
                    transform.position = new Vector3(transform.position.x, smoothedPosition.y, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, smoothedPosition.y, smoothedPosition.z);
                }
            }
        }
        else
        {
            isMoving = false;
            if (GlobalVariables.outOfBounds) { 
            if (!hasTransitioned)
            {
                transitionedPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + (transform.position.z > 0 ? -5f : 5f));
                hasTransitioned = true;
            }
            smoothedPosition = Vector3.Lerp(transform.position, transitionedPos, 0.05f);
            hasTransitioned = true;
            transform.position = smoothedPosition;
            
        }
        }
    }
    void LateUpdate()
    {
        if(isMoving) transform.position += Vector3.right * Time.deltaTime * 0.5f;
        if (tileInfo.GetComponent<TileMapGenerator>().currentPos-20 < transform.position.x)
        {
            tileInfo.GetComponent<TileMapGenerator>().CreateTileMap();
        }
    }
}
