using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    [SerializeField] private bool useTouchscreen = true;
    private CharacterController controller;
    Vector3 move;

    private void Start() 
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    //public void FixedUpdate()
    public void Update()
    {

        if (useTouchscreen) { move = new Vector3(variableJoystick.Horizontal, 0 , variableJoystick.Vertical); }
        else                { move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); }

        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        controller.Move(move * Time.deltaTime * speed);
    }
}