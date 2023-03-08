using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private int _health = 10;
    private int _speed;
    
    [SerializeField] public HealthContainer hc;


    private void Start()
    {
        hc.UpdateHealth(_health);
    }

}
