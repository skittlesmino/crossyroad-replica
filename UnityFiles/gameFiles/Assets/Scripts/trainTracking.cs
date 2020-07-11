using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainTracking : MonoBehaviour
{
    float speed = 40;
    

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        gameObject.transform.Translate(0, 0, 1 * speed * Time.deltaTime);
        if (gameObject.transform.position.z > 60)
        {
            Destroy(gameObject);
            transform.parent.GetComponent<trainPassing>().hasPassed = true;
        }

    }
}
