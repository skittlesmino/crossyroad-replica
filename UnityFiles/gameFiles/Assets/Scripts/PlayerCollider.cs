using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private GameObject player;
    public bool carDeath = false;
    public AudioSource[] playerSounds;
    bool hasDied = false;
    public bool fallingDeath;
    void Start()
    {
         player = GameObject.Find("Chicken");
         playerSounds = player.GetComponents<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water") && !hasDied)
        {
            GameObject.Find("Chicken").GetComponent<PlayerState>().Death();
            fallingDeath = true;

        }
        else if ((other.CompareTag("Car") || other.CompareTag("Train")) && !hasDied)
        {

            GameObject.Find("Chicken").GetComponent<PlayerState>().Death();
            carDeath = true;
            playerSounds[0].Play();
            hasDied = true;
        }

    }
}
