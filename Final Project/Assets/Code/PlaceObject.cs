using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceObject : MonoBehaviour
{
    // The current way the bridge is placed for touch is within the PlayerMovement script. 
    // Not sure how to make it so that it could be one script for both touch and keyboard
    // but the button ui is prett simple compared to doing it here

    public GameObject bridge;

    void Update() {

        if (Input.GetKeyDown("space")) {
            Instantiate(bridge, new Vector3(GameObject.FindWithTag("Player").transform.position.x - 6f, 0.1f, 0f), Quaternion.identity);
        }
    }
}