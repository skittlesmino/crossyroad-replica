using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayer : MonoBehaviour
{
    Animator logAnim;
    Animator playerAnim;
    public AudioSource[] logSound;
    int num;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            logSound = gameObject.GetComponents<AudioSource>();
            GameObject.Find("PlayerParent").transform.parent = transform;
            GameObject.Find("Camera").transform.parent = transform;
            num = Random.Range(0, 2);
            if (!logSound[0].isPlaying && !logSound[1].isPlaying) logSound[num].Play();
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("PlayerParent").transform.parent = null;
            GameObject.Find("Camera").transform.parent = null;
        }
    }
    
}
