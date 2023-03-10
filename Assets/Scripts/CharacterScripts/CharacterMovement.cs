using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
 public CharacterController controller;
 private Rigidbody _rigidBody;
 
 private void Start()
 {
     _rigidBody = GetComponent<Rigidbody>();
 }

 private float speed = 5.0f;
    
    // Update is called once per frame
    void Update()
    {
        // Get inputs
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        // Move functionality

        Vector3 direction = transform.right * horizontal + transform.forward * vertical;
        controller.Move(direction * speed * Time.deltaTime);
        
        controller.Move(Vector3.down);
    }
    

}
