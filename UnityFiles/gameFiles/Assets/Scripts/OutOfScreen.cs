using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfScreen : MonoBehaviour
{
    public Camera mainCamera;
    Vector2 screenposition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        screenposition = mainCamera.WorldToScreenPoint(transform.position);
        if ((screenposition.y-20) < 0)
        {
            GameObject.Find("Chicken").GetComponent<PlayerState>().Death();
        }
    }
}
