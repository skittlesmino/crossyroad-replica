using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObject : MonoBehaviour
{
    Camera cam;
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
    }

    void Update()
    {
        if (cam.transform.position.x > gameObject.transform.position.x)
        Destroy(gameObject);
    }
}
