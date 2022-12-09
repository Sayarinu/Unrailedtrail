using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon: MonoBehaviour
{
    [SerializeField] public float speed = 0.02f;
    [SerializeField] public float speed_up_factor = 1.000001f;
    private int rotation_multiplier = 45;
    
    // public variables for 4 wheels of the wagon
    public GameObject BL;
    public GameObject BR;
    public GameObject FL;
    public GameObject FR;

    // Start is called before the first frame update
    void Start()
    {
        // randomly set the wheel's initail rotation
        BL.transform.Rotate(0, 0, Random.Range(0, 360));
        BR.transform.Rotate(0, 0, Random.Range(0, 360));
        FL.transform.Rotate(0, 0, Random.Range(0, 360));
        FR.transform.Rotate(0, 0, Random.Range(0, 360));
    }

    // Update is called once per frame
    void Update()
    {
        speed *= speed_up_factor;

        // rotate wheels according to speed
        BL.transform.Rotate(0, 0, speed * rotation_multiplier % 360);
        BR.transform.Rotate(0, 0, speed * rotation_multiplier % 360);
        FL.transform.Rotate(0, 0, speed * rotation_multiplier % 360);
        FR.transform.Rotate(0, 0, speed * rotation_multiplier % 360);
    }

    void FixedUpdate()
    {
        transform.Translate(-speed, 0, 0);
    }
}
