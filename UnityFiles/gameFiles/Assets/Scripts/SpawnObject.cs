using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{

    public GameObject Spawnable;
    GameObject childLog;
    GameObject PrefabGO;
    private Vector3 pos;
    public int spawnSide;
    int spawnTimeOut;
    float middleOffset;
    int i = 0;
    int z, Rate;
    public float speed;
    float logTimer;
    float length;
    void Start()
    {
        int index = transform.GetSiblingIndex();
        Rate = Random.Range(2,5);
        logTimer = Time.time + Rate;
        spawnSide = index % 2 == 0 ? 1 : -1;
        spawnTimeOut = Rate;
        z = spawnSide < 0 ? 9 : -9;
        speed = Random.Range(2f, 4f);
        length = Random.Range(0.5f, 1.7f);
        SpawnPrefab();
        
    }

    void SpawnPrefab()
    {
        PrefabGO = Instantiate(Spawnable);
        PrefabGO.transform.position = new Vector3(gameObject.transform.position.x + middleOffset,0.1f, z);
        SetPrefabInfo(PrefabGO);
        i++;
    }

    void SetPrefabInfo(GameObject GO)
    {
        childLog = GO.transform.GetChild(0).gameObject;
        childLog.transform.localScale = new Vector3(childLog.transform.localScale.x, childLog.transform.localScale.y - 0.5f, length );
        GO.transform.parent = transform;
        GO.name = "Vehicle" + i;

    }

    void Update()
    {
        
        if (Time.time > logTimer)
        {
            logTimer += Rate;
            SpawnPrefab();

        }
    }

    
}
