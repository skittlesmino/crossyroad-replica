using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapGenerator : MonoBehaviour
{
    public GameObject[] tileArray = new GameObject[4];
    public GameObject musicLoader;
    public int currentPos = 5;
    int biomeLength;
    int MapPos = 0;
    int biomeNumber;
    int gap;
    float space;
    int holder = 0;
    int ChangedBiomeNumber;
    bool differentThanLast = false;
    int lastBiomeNumber = 10;
    
    void Start()
    {
        
        for (float x = -4.5f; x < 4.5f; x += 1)
        {
            GameObject TempGO = Instantiate(tileArray[0]);
            TempGO.transform.position = new Vector3((float)x + 1f, 0, MapPos);
            SetTileInfo(TempGO, x, MapPos);
        }

        while(currentPos < 15)
        CreateTileMap();
        
    }


    public void CreateTileMap()
    {

        generateBiomeNumber();


        for (int x = currentPos; x < biomeLength + currentPos; x += gap)
        {
            holder += gap;
            GameObject TempGO = Instantiate(tileArray[ChangedBiomeNumber]);
            TempGO.transform.position = new Vector3((float)x + space, 0, MapPos);
            SetTileInfo(TempGO, x, MapPos);
        }

        if (ChangedBiomeNumber == 1)
        {
            GameObject musicGO = Instantiate(musicLoader);
            musicGO.transform.position = new Vector3((currentPos + holder / 2), 0, 0);
            musicGO.transform.localScale = new Vector3(holder+1, 3, 18);
        }

        currentPos += holder;
        holder = 0;
    }

    void SetTileInfo(GameObject GO,float x, float z)
    {
        GO.transform.parent = transform;
        GO.name = x.ToString() + " " + z.ToString();
    }


    void generateBiomeNumber()
    {
        biomeNumber = Random.Range(0, 21);
        if (biomeNumber >= 3 && biomeNumber <= 17)
            biomeLength = Random.Range(1, 7);
        else biomeLength = Random.Range(1, 3);
        if (biomeNumber > 3 && biomeNumber <= 10)
        {
            gap = 2;
            space = 1f;
        }
        else
        {
            gap = 1;
            space = 0.5f;
        }

        if (biomeNumber <= 3) ChangedBiomeNumber = 0;
        else if (biomeNumber > 3 && biomeNumber <= 10) ChangedBiomeNumber = 1;
        else if (biomeNumber > 10 && biomeNumber <= 17) ChangedBiomeNumber = 2;
        else ChangedBiomeNumber = 3;
        
        if(lastBiomeNumber == ChangedBiomeNumber)
        {
            generateBiomeNumber();
        }
        lastBiomeNumber = ChangedBiomeNumber;
    }
}
