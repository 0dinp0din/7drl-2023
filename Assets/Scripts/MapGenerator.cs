using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private int mapPosX = 0;
    private int mapPosZ = 0;
    
    private int mapSize = 10;
    private int randomNum;

    public GameObject plane;
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        for (int i = 0; i < mapSize; i++)
        {
            randomNum = Random.Range(0, 2);
            
            Instantiate(plane, new Vector3(mapPosX, 0, mapPosZ), Quaternion.identity);

            if (randomNum == 0)
            {
                mapPosX += 20;
            } else if (randomNum == 1)
            {
                mapPosZ += 20;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
