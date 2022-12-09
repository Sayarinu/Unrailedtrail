using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonDamageController : MonoBehaviour
{

    public WagonHealthBar healthbar;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Damage(5); // obstacles currently deal 5 hp
        }
        else if (other.gameObject.tag == "Weapon")
        {
            Fix(5); // weapons currently heal 5 hp
        }
    }

    public void Damage(int amt)
    {
        PublicVars.health -= amt;
        healthbar.UpdateHealthBar();
    }

    public void Fix(int amt)
    {
        // cost wood to fix wagon
        if (PublicVars.wood >= amt && PublicVars.health < PublicVars.maxHealth)
        {
            PublicVars.health += amt;
            PublicVars.wood -= amt;
            healthbar.UpdateHealthBar();
        }
    }

}
