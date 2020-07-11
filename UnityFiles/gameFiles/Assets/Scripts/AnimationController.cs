using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator anim;
    public GameObject thePlayer;
    public GameObject thePlayerActual;
    public ParticleSystem particle;
    float x;
    float z;
    bool hasDied = false;
    playerMovement moveScript;
    PlayerCollider onCollision;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        moveScript = thePlayer.GetComponent<playerMovement>();
        onCollision = thePlayerActual.GetComponent<PlayerCollider>();
    }


    void Update()
    {
        if (moveScript.justJump == true)
        {
            anim.SetBool("Jump", true);
        } else
        {
            anim.SetBool("Jump", false);
        }

        if (onCollision.carDeath == true && !hasDied)
        {
            anim.SetTrigger("deathVehicle");
            hasDied = true;
        }
        if(onCollision.fallingDeath == true && !hasDied)
        {
            thePlayer.GetComponent<playerMovement>().playerSounds[6].Play();
            anim.SetTrigger("deathWater");
            hasDied = true;
            particle.transform.position = thePlayer.transform.position;
            particle.Play();
            
        }

        x = Input.GetAxis("w");
        z = Input.GetAxis("d");

        if (thePlayerActual.GetComponent<PlayerState>().isAlive == true) { 
            if (Input.GetButtonDown("w"))
            {

                if (x == 1) gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
                else if (x == -1) gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);


            }
            else if (Input.GetButtonDown("d"))
            {

                if (z == 1) gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                else if (z == -1) gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);

            }
    }
    }

}
