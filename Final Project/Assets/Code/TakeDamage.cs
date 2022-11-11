using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] public GameObject wagon;
    [SerializeField] public int rockHealth = 1;
    public AudioSource rockSmash;

    void OnTriggerEnter(Collider other) 
    {
        //wagon.health--;
        //Screenshake & other effects
        rockHealth--;
        if (rockHealth <= 0)
        {
            rockSmash.Play(0);
            Destroy(this);
        }
        
    }

    private void OnDestroy() 
    {
        
    }
}
