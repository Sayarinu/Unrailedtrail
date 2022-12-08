using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //public PublicVars publicvars = new PublicVars();
    public AudioSource enemyHitSound;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            enemyHitSound.Play();
            Destroy(gameObject); // or reduce health
        }
    }
}
