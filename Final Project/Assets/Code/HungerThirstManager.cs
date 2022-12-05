using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerThirstManager : MonoBehaviour
{
    public BarHungerThirst resources;
    public PublicVars publicvars;

    public int hunger_decay = 5; // reduces hunger and thirst by 5pt every 30sec
    public int thirst_decay = 5;

    void Start()
    {
        StartCoroutine(Timer(30));
    }

    IEnumerator Timer(int time)
    {
        yield return new WaitForSeconds(time); // waits 30sec to decay hunger/thirst 

        publicvars.hunger -= hunger_decay;
        resources.UpdateHungerBar();

        publicvars.thirst -= thirst_decay;
        resources.UpdateThirstBar();

    }
}