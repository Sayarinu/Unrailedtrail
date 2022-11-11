using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] public GameObject wagon;
    [SerializeField] public int rockHealth = 1;
    public AudioSource rockSmash;
    private int playerHealth;

    private void Awake()
    {
    }

    void OnTriggerEnter(Collider other) 
    {
        //Wagon.Damage(1);
        //Screenshake & other effects
        if (other.tag == "Wagon")
        {
            rockHealth--;
            rockSmash.Play();
            if (rockHealth <= 0)
            {
                Destroy(gameObject);        
            }
            else
            {
                // push wagon back
            }
        }
        
    }

    private void OnDestroy() 
    {
        
    }
}
