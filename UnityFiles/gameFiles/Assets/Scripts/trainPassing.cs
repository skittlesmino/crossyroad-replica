    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class trainPassing : MonoBehaviour
{
    float spawnTimer;
    float lightTimer;
    float Rate;
    public GameObject Spawnable;
    GameObject PrefabGO;
    Animator anim;
    public bool hasPassed = true;
    bool canSpawn = false;
    bool canFlash = false;
    public AudioSource bellSound;
    void Start()
    {
        Rate = Random.Range(4f, 10f);
        anim = transform.Find("Lights").GetComponent<Animator>();
        bellSound = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        if (hasPassed)
        {
            lightTimer = Time.time + Rate;
            spawnTimer = lightTimer + 1.5f;
            canSpawn = true;
            canFlash = true;
        }
            if (Time.time > lightTimer && canFlash)
            {
                anim.Play("lightChange");
            bellSound.Play();
            hasPassed = false;
            canFlash = false;
            }
            if (Time.time > spawnTimer && canSpawn)
            {
                SpawnPrefab();
            canSpawn = false;
            }
        if (hasPassed)
        {
            lightTimer = Time.time + Rate;
            hasPassed = false;
        }

    }



    void SpawnPrefab()
    {
        PrefabGO = Instantiate(Spawnable);
        PrefabGO.transform.position = new Vector3(gameObject.transform.position.x, 0.1f, -20);
        SetPrefabInfo(PrefabGO);
    }

    void SetPrefabInfo(GameObject GO)
    {
        GO.transform.parent = transform;
        GO.name = "train";
    }


}
