using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonDamageController : MonoBehaviour
{

    [SerializeField] public float health = 100;
    [SerializeField] public float maxHealth = 100;

    public WagonHealthBar healthbar;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Damage(5); // obstacles currently deal 5 hp
        }
    }

    public void Damage(int amt)
    {
        health -= amt;
        healthbar.UpdateHealthBar();
    }

}
