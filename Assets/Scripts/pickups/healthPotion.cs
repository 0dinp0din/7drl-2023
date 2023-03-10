using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class healthPotion : MonoBehaviour
{
    private CharacterStats player;

    private void Start()
    {
        player = FindObjectOfType<CharacterStats>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.AddPotion();
            Destroy(gameObject);
        }
    }
}
