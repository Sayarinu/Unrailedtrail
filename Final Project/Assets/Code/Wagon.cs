using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonMove : MonoBehaviour
{
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
        transform.Translate(-0.1f, 0, 0);
    }
}
