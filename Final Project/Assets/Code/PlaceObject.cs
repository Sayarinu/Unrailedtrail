using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceObject : MonoBehaviour
{

    public GameObject bridge;
    bool gameRunning;

    void Start() {
        gameRunning = true;
        StartCoroutine(buildBridge());
    }
    IEnumerator buildBridge() {

        if (Input.GetKeyDown("space")) {
            Instantiate(bridge, new Vector3(GameObject.FindWithTag("Player").transform.position.x - 6f, 0.1f, 0f), Quaternion.identity);
        }

    while (gameRunning) {
        foreach (Touch touch in Input.touches) {
            int id = touch.fingerId;
                if (EventSystem.current.IsPointerOverGameObject(id))
                {
                    Instantiate(bridge, new Vector3(GameObject.FindWithTag("Player").transform.position.x - 6f, 0.1f, 0f), Quaternion.identity);
                }
            }
            yield return new WaitForSeconds(10);
        }
    }
}