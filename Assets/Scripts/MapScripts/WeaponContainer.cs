using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponContainer : MonoBehaviour
{
    private Animator weapon;
    private float timeStamp;


    private void Start()
    {
        weapon = transform.GetChild(0).GetComponent<Animator>();
        timeStamp = Time.time + 4;
    }

    private void Update()
    {
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (timeStamp <= Time.time)
            {
                timeStamp = Time.time + 4;
                Debug.Log("click");
                weapon.SetTrigger("attack");
            }


        }

    }
}
