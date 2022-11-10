using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] public GameObject wagon;


    void OnTriggerEnter(Collider other) 
    {
        wagon.health--;
        //Screenshake?
    }
}
