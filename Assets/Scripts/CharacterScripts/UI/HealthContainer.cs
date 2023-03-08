using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthContainer : MonoBehaviour
{
    
    public GameObject heart;

    public void UpdateHealth(int health)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < health; i++) {
                GameObject heart = Instantiate(this.heart, transform.position, Quaternion.identity);
                heart.transform.SetParent(transform);
        }
    }
}
