using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject[] pickups;

    private void Start()
    {
        int rand = Random.Range(0, pickups.Length);
        Instantiate(pickups[rand], transform.position, Quaternion.identity);
    }
}
