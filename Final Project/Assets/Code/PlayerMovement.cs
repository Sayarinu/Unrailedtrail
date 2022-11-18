using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    [SerializeField] private bool useTouchscreen = true;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = -2f;
    [SerializeField] private float jump = 5f;
    private Vector3 playerVelocity;
    private CharacterController controller;
    private Vector3 move;

    private void Start() 
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    //public void FixedUpdate()
    public void Update()
    {

        // Move using either touchscreen or WASD for testing
        if (useTouchscreen) { 
            move = new Vector3(variableJoystick.Horizontal, 0, variableJoystick.Vertical);
        }
        else { 
            move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        controller.Move(move * Time.deltaTime * speed);

        // Rotate
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        // Jump
        if (Input.GetButtonDown("Jump")) { 
            playerVelocity.y += Mathf.Sqrt(jump * -3.0f * gravity);
        }
        
        playerVelocity.y += (gravity * Time.deltaTime);
        controller.Move(playerVelocity * Time.deltaTime);
    }
}