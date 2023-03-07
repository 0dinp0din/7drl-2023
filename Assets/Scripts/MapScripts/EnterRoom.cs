using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnterRoom : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] enemySpawns;

    private bool hasTriggered = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered)
        {
            foreach (var enemy in enemySpawns)
            {
                int rand = Random.Range(0, enemies.Length);
                Instantiate(enemies[rand], enemy.transform.position, Quaternion.identity);
            }

            hasTriggered = true;
        }
    }

}
