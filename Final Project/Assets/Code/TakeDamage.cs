using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] public GameObject wagon;
    [SerializeField] public int rockHealth = 1;
    public AudioSource rockSmash;

    private void Awake()
    {
        //wagon = GetComponent<GameObject>();
        rockSmash = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) 
    {
        //Wagon.health--;
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
