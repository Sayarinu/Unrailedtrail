using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodChop : MonoBehaviour
{
    public PublicVars publicvars = new PublicVars();
    public AudioSource woodChopSound;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            publicvars.wood ++;
            woodChopSound.Play();
            Destroy(gameObject);
        }
    }
}