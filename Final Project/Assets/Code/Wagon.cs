using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon: MonoBehaviour
{
    [SerializeField] public float speed = 0.02f;
    [SerializeField] public int health = 3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.Translate(-speed, 0, 0);
    }
}
