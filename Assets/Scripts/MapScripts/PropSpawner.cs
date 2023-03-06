using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpawner : MonoBehaviour
{
    public GameObject[] props;

    private void Start()
    {
        int rand = Random.Range(0, props.Length);
        Instantiate(props[rand], transform.position, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
    }
}
