using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterDeath : MonoBehaviour
{
  
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("Chicken").GetComponent<PlayerState>().Death();
            Camera.main.transform.parent = null;
            GlobalVariables.outOfBounds = true;
        }
    }

}
