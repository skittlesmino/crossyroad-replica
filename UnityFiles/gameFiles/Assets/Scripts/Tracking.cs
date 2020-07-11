using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    int z, Rate;
    int spawnSide;
    float decayingSpeed;
    public float fixSpeed;
    public float speed;
    float slowRate;

    void Start()
    {
        int index = transform.GetSiblingIndex();
        spawnSide = gameObject.transform.parent.GetComponent<SpawnObject>().spawnSide;
        fixSpeed = gameObject.transform.parent.GetComponent<SpawnObject>().speed;
        z = spawnSide < 0 ? 9 : -9;
        decayingSpeed = fixSpeed * 3f;
        slowRate = 0.01f;
    }

    void FixedUpdate()
    {

        if ((gameObject.transform.position.z > 5 || gameObject.transform.position.z < (-5)))
            speed = decayingSpeed;
        else if(speed > fixSpeed)
        {
            speed -= slowRate;
            slowRate += 0.08f;
        }
        gameObject.transform.Translate(0, 0, 1 * spawnSide * speed * Time.deltaTime);
        if (Mathf.Abs(gameObject.transform.position.z) > 14)
        {
            Destroy(gameObject);
        }
        //if (decayingSpeed > speed) decayingSpeed -= 0.03f;
    }
}