using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObjects : MonoBehaviour
{

    public GameObject[] spawnable;
    GameObject GO;
    int count = 0;
    bool dontSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
        GO = Instantiate(spawnable[Random.Range(0, 2)]);
        GO.transform.position = new Vector3(gameObject.transform.position.x, 0,5.5f);
        GO.transform.parent = gameObject.transform;
        GO = Instantiate(spawnable[Random.Range(0, 2)]);
        GO.transform.position = new Vector3(gameObject.transform.position.x, 0, -5.5f);
        GO.transform.parent = gameObject.transform;
        spawnPrefab();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnPrefab()
    {
        if (gameObject.transform.position.x > -0.7 && gameObject.transform.position.x < 1.5)
            dontSpawn = true;
        for (float z = -8.5f; z < -5.5f; z++)
        {
            if ((Random.Range(0f, 1f)) > 0.5f)
            {
                GO = Instantiate(spawnable[Random.Range(0, 2)]);
                GO.transform.position = new Vector3(gameObject.transform.position.x, 0, z);
                GO.transform.parent = gameObject.transform;
                
            }
        }

        for (float z = -4.5f; z <= 4.5; z++) {
            if(dontSpawn && z<=1.5 && z >= -1.5)
            {
            }else if ((Random.Range(0f, 1f)) > 0.9f && count < 2)
            {
                GO = Instantiate(spawnable[Random.Range(0, 2)]);
                GO.transform.position = new Vector3(gameObject.transform.position.x, 0, z);
                GO.transform.parent = gameObject.transform;
                count++;
            }
            else if((Random.Range(0f, 1f)) > 0.8f)
            {
                GO = Instantiate(spawnable[Random.Range(2, 5)]);
                GO.transform.position = new Vector3(gameObject.transform.position.x + Random.Range(-.2f,.2f), 0, z + Random.Range(-.1f, .2f));
                GO.transform.parent = gameObject.transform;
            }
                  
        }

        for (float z = 8.5f; z > 5.5f; z--)
        {
            if ((Random.Range(0f, 1f)) > 0.5f)
            {
                GO = Instantiate(spawnable[Random.Range(0, 2)]);
                GO.transform.position = new Vector3(gameObject.transform.position.x, 0, z);
                GO.transform.parent = gameObject.transform;
            }
        }
    }
}
