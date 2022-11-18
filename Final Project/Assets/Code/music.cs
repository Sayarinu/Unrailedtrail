using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
        // check if another music player exists
        if (FindObjectsOfType(GetType()).Length > 1) {
            Destroy(gameObject);
        }
    }
}
