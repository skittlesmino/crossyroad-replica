using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carTracking : MonoBehaviour
{
    GameObject player;
    int spawnSide;
    public AudioSource carSound;
    float location;
    void Start()
    {
        spawnSide = gameObject.transform.parent.GetComponent<SpawnCar>().spawnSide;
        location = gameObject.transform.parent.transform.parent.transform.position.x;
        
        player = GameObject.FindGameObjectWithTag("Player");
        carSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(player != null)
      if(Mathf.Round(player.transform.position.x+0.2f) == (location) || Mathf.Round(player.transform.position.x + 0.2f) == (location+1)) {
            if (spawnSide == -1)
        {
            if (player.transform.position.z < gameObject.transform.position.z-4)
                carSound.Play();
        }else
        {
            if (player.transform.position.z > gameObject.transform.position.z+4)
                carSound.Play();
        }
        
    }
    }
}