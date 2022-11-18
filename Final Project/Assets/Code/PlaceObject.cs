using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceObject : MonoBehaviour
{

    public GameObject bridge;

    void Update() {

        if (Input.GetKeyDown("space")) {
            Instantiate(bridge, new Vector3(GameObject.FindWithTag("Player").transform.position.x - 6f, 0.1f, 0f), Quaternion.identity);
        }

        foreach (Touch touch in Input.touches) {
            int id = touch.fingerId;
                if (EventSystem.current.IsPointerOverGameObject(id))
                {
                    Instantiate(bridge, new Vector3(GameObject.FindWithTag("Player").transform.position.x - 6f, 0.1f, 0f), Quaternion.identity);
                }
            }
        }
}