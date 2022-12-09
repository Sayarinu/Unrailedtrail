using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChop : MonoBehaviour
{
    public AudioSource enemyHitSound;
    [SerializeField] private int foodAmt = 10;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            enemyHitSound.Play();

            // public vars hunger increased by foodAmt until reaches hungerMax
            if (PublicVars.hunger < PublicVars.hungerMax)
            {
                PublicVars.hunger += foodAmt;
                if (PublicVars.hunger > PublicVars.hungerMax)
                {
                    PublicVars.hunger = PublicVars.hungerMax;
                }
            }

            // currently it destroys the enemy on hit
            Destroy(gameObject); 
        }
    }  
} 