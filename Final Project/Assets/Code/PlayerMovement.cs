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
    [SerializeField] private float speed_multiplier = 1.0001f;
    [SerializeField] private float gravity = -2f;
    private Vector3 playerVelocity;
    private CharacterController controller;
    private Vector3 move;
    private int currentX = 0;
    private float GROUND_HEIGHT = 0.6f;

    public GameObject bridge;
    public GameObject terrain;
    public GameObject axe;
    public GameObject wood;
    public GameObject wolf;

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
        speed *= speed_multiplier;
        controller.Move(move * Time.deltaTime * speed);

        // Rotate
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }
        
        playerVelocity.y += (gravity * Time.deltaTime);
        controller.Move(playerVelocity * Time.deltaTime);

        if (GameObject.FindWithTag("Player").transform.position.x < currentX - 20) {
            currentX -= 115;
            GenerateTerrain();
        }

        // if player falls in under GROUND_HEIGHT, respawn
        if (GameObject.FindWithTag("Player").transform.position.y < GROUND_HEIGHT) {
            GameObject.FindWithTag("Player").transform.position = new Vector3(
                GameObject.FindWithTag("Player").transform.position.x + 5, 0, Random.Range(-5, 5));
        }
    }

    public void PlaceBridge(){
        if (PublicVars.wood >= 5) {
            PublicVars.wood -= 5;
            Instantiate(bridge, new Vector3(GameObject.FindWithTag("Player").transform.position.x - 6f, 0.01f, 0f), Quaternion.identity);
        }
    }

    public void GenerateTerrain() {
        Instantiate(terrains[Random.Range(0, terrains.Length)], new Vector3(currentX, -6.678398f, 6.20949f), Quaternion.identity);
        // generate wood within the terrain in random positions
        for (int i = 0; i < Random.Range(1, 4); i++) {
            Debug.Log("Generating wood");
            Instantiate(wood, new Vector3(currentX + Random.Range(-10, 10), .57f, Random.Range(-5, 5)), Quaternion.identity);
        }
        // generate wolf within the terrain in random positions
        for (int i = 0; i < Random.Range(0, 2); i++) {
            Debug.Log("Generating wolf");
            Instantiate(wolf, new Vector3(currentX + Random.Range(-10, 10), -1.46f, Random.Range(-5, 5)), Quaternion.identity);
        }
        
    }
}