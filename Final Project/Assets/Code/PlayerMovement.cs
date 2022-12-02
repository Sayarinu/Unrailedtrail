using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    [SerializeField] GameObject[] terrains;
    [SerializeField] private bool useTouchscreen = true;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = -2f;
    [SerializeField] private float jump = 5f;
    private Vector3 playerVelocity;
    private CharacterController controller;
    private Vector3 move;
    private int currentX = 0;
    private double DROP_HEIGHT = 0.6;

    public GameObject bridge;
    public GameObject terrain;
    public GameObject axe;

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

        if (GameObject.FindWithTag("Player").transform.position.x < currentX - 20) {
            currentX -= 115;
            GenerateTerrain();
        }

        // if player falls lower than ground, reset position
        if (GameObject.FindWithTag("Player").transform.position.y < DROP_HEIGHT) {
            // transform player x position + 5 with random z position within range
            GameObject.FindWithTag("Player").transform.position = new Vector3(
                GameObject.FindWithTag("Player").transform.position.x + 5, 0, Random.Range(-5, 5));
        }

    }

    public void PlaceBridge(){
        Instantiate(bridge, new Vector3(GameObject.FindWithTag("Player").transform.position.x - 6f, 0.1f, 0f), Quaternion.identity);
    }

    public void SwingAxe(){
        
    }

    public void GenerateTerrain() {
        Instantiate(terrains[Random.Range(0, terrains.Length)], new Vector3(currentX, -6.678398f, 6.20949f), Quaternion.identity);
    }
}