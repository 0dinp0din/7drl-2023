using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private int mapPosZ;
    
    private int mapSize = 10;

    public GameObject[] mapChunks;
    public GameObject[] startChunk;
    public GameObject[] bossChunk;
    
    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        
        for (int i = 0; i < mapSize; i++)
        {
            if (i == 0)
            {
                Instantiate(startChunk[Random.Range(0, startChunk.Length)], new Vector3(0, 0, mapPosZ), Quaternion.identity); 
            } else if (i == mapSize-1)
            {
                Instantiate(bossChunk[Random.Range(0, bossChunk.Length)], new Vector3(0, 0, mapPosZ), Quaternion.identity); 
            }else
            {
                Instantiate(mapChunks[Random.Range(0, mapChunks.Length)], new Vector3(0, 0, mapPosZ), Quaternion.identity); 
            }
            
            mapPosZ += 40;
        }
    }

}
