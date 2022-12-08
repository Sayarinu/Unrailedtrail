using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PublicVars publicvars = new PublicVars();
    public AudioSource enemyHitSound;
    [SerializeField] private int foodAmt = 10;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            enemyHitSound.Play();
            // enemy.health --;
            // if (health <= 0) {
            publicvars.hunger += foodAmt; // when 
            Destroy(gameObject); // or reduce health
            // }
        }
    }
}
