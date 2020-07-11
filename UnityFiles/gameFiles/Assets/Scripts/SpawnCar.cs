using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{

    public GameObject Spawnable;
    GameObject PrefabGO;
    private Vector3 pos;
    public float speed;
    float decayingSpeed;
    public int spawnSide;
    float spawnTimeOut;
    float middleOffset;
    int i = 0;
    int z;
    float Rate;
    List<GameObject> SpawnedObjects = new List<GameObject>();
    int rotation = 0;
    float carTimer;
    void Start()
    {
        int index = transform.GetSiblingIndex();
        Rate = Random.Range(3f, 5f);
        carTimer = Time.time + Rate;
        spawnSide = Random.Range(-1,1) >= 0 ? 1 : -1;
        if (spawnSide == -1) rotation = 180;
        spawnTimeOut = Rate;
        speed = Random.Range(2f, 4f);
        z = spawnSide < 0 ? 9 : -9;
        if (gameObject.name == "firstLane")
        {
            middleOffset = 0.5f;
        }
        else if (gameObject.name == "secondLane") middleOffset = -0.5f;
        SpawnPrefab();

    }

    void SpawnPrefab()
    {

        SpawnedObjects.Add(Instantiate(Spawnable));
        SpawnedObjects.Last().transform.position = new Vector3(gameObject.transform.position.x + middleOffset, 0f, z);
        SetPrefabInfo(SpawnedObjects.Last());
        decayingSpeed = speed * 3f;
        i++;
    }

    void SetPrefabInfo(GameObject GO)
    {
        GO.transform.rotation = Quaternion.Euler(0, rotation, 0); ;
        GO.transform.parent = transform;
        GO.name = "Vehicle" + i;

    }

    void FixedUpdate()
    {

        for (int j = 0; j < SpawnedObjects.Count; j++)
        {
            if (SpawnedObjects[j] != null)
            {
                SpawnedObjects[j].transform.Translate(0, 0, 1 * speed * Time.deltaTime);
                if (Mathf.Abs(SpawnedObjects[j].transform.position.z) > 14)
                {
                    Destroy(SpawnedObjects[j]);
                    SpawnedObjects.RemoveAt(0);
                }
            }
        }
        if (Time.time > carTimer)
        {
            carTimer += Rate;
            SpawnPrefab();
        }
    }


}
