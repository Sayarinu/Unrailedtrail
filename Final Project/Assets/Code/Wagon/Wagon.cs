using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon: MonoBehaviour
{
    [SerializeField] public float speed = 0.02f;

    // Update is called once per frame
    void Update()
    {
        speed *= 1.000001f;
    }

    void FixedUpdate()
    {
        transform.Translate(-speed, 0, 0);
    }
}
