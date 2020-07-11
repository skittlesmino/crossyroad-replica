using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicCollider : MonoBehaviour
{

    public AudioSource roadSound;

    void Start()
    {
        roadSound = GetComponent<AudioSource>();
        
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            StartCoroutine("fadeInSound");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine("fadeOutSound");
        }
    }

    IEnumerator fadeInSound()
    {
        
        while (roadSound.volume < 0.15f)
        {
            roadSound.volume += Time.deltaTime / 3f;
            yield return null;
        }
    }

    IEnumerator fadeOutSound()
    {
        
        while (roadSound.volume > 0.0f)
        {
            
            roadSound.volume -= Time.deltaTime / 3f;
            yield return null;
        }
        
    }


}
