using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private float _health = 100;
    private int _speed;
    
    [SerializeField] public HealthContainer hc;


    private void Start()
    {
        hc.setMaxHealth(_health);
    }
    
    public void TakeDamage(float damage)
    {
        _health -= damage;
        hc.setHealth(_health);

        if (_health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Skjerm for å vise at spillet er over og spør om å prøve igjen
    }

}
