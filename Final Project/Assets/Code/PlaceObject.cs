using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    public GameObject bridge;

    void Update() {
        if (Input.GetKeyDown("space")) {
            GameObject prefab = bridge;
            GameObject tree = Instantiate(prefab, transform);
            tree.transform.position = GameObject.FindWithTag("Player").transform.position;
        }
    }
}
