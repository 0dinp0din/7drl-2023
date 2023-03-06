using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemies;

    private void Start()
    {
        int rand = Random.Range(0, enemies.Length);
        Instantiate(enemies[rand], transform.position, Quaternion.identity);
    }
}
