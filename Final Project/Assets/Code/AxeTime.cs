using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeTime : MonoBehaviour
{
    [SerializeField] int timerActive = 60;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        

        timerActive--;
        if(timerActive == 0) { Destroy(gameObject); }
    }
}
