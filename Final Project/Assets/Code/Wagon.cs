using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon: MonoBehaviour
{
    [SerializeField] public float speed = 0.02f;

    [SerializeField] public int health = 100;
    [SerializeField] public float maxHealth = 100;

    public WagonHealthBar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed *= 1.000001f;
    }

    void FixedUpdate()
    {
        transform.Translate(-speed, 0, 0);
    }

    public void Damage(int amt)
    {
        health -= amt;
        healthbar.UpdateHealthBar();
    }
}
