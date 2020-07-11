using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    public AudioSource trainSound;

    void Start()
    {
        trainSound = GetComponent<AudioSource>();
        trainSound.Play();
        StartCoroutine("fadeSound");
    }

    IEnumerator fadeSound()
    {
        while(trainSound.volume > 0.01f)
        {
            trainSound.volume -= Time.deltaTime / 2.0f;
            yield return null;
        }
    }

}

