using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   

    public CharacterController controller;
    public float speed = 8f;
    public float gravity = -9.81f;
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;

    Vector3 velocity;
    bool isGrounded;
    float z;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 21f;
        } 

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 8f;
        }

        
        float x = Input.GetAxis("Horizontal");
        

        if(Input.GetKeyDown(KeyCode.Z))
        {
            z = 1;
        }

        if(Input.GetKeyUp(KeyCode.Z))
        {
            z = 0;
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            z = -1;
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            z = 0;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
