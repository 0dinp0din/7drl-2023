using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
 public CharacterController controller;
 
    private float speed = 1.0f;
    
    // Update is called once per frame
    void Update()
    {
        // Get inputs
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //Walk and run stuff
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w"))
        {
            speed = 8;
        }

        if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w"))
        {
            speed = 5;
        }


        // Move functionality

        Vector3 direction = transform.right * horizontal + transform.forward * vertical;
        controller.Move(direction * speed * Time.deltaTime);
    }

}
