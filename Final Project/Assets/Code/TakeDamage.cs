using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    //[SerializeField] public GameObject wagon;
    [SerializeField] public int rockHealth = 1;
    public AudioSource rockSmash;

    private void Awake()
    {
        //wagon = GameObject.FindGameObjectWithTag("Wagon");
        //rockSmash = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) 
    {
        //wagon.health--;
        //Screenshake & other effects
        if (other.tag == "Wagon")
        {
            rockHealth--;
            if (rockHealth <= 0)
            {
                rockSmash.Play();
                Destroy(gameObject);
            }
        }
        
    }

    private void OnDestroy() 
    {
        
    }
}
