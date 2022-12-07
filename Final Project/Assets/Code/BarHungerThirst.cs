using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarHungerThirst : MonoBehaviour
{
    public Image hungerBarImage;
    public Image thirstBarImage;
    public Image woodBarImage;
    public PublicVars publicvars;

    public int hunger_decay = 5; // reduces hunger and thirst by 5pt every 30sec
    public int thirst_decay = 5;

    void Start()
    {
        StartCoroutine(Timer(1));
    }

    IEnumerator Timer(int time)
    {
        yield return new WaitForSeconds(time); // waits 30sec to decay hunger/thirst 

        publicvars.hunger -= hunger_decay;
        UpdateHungerBar();

        publicvars.thirst -= thirst_decay;
        UpdateThirstBar();

    }

    public void UpdateHungerBar()
    {
        hungerBarImage.fillAmount = Mathf.Clamp(publicvars.hunger / publicvars.hungerMax, 0, 1f);
    }

    public void UpdateThirstBar()
    {
        thirstBarImage.fillAmount = Mathf.Clamp(publicvars.thirst / publicvars.thirstMax, 0, 1f);
    }

    public void UpdateWoodBar()
    {
        woodBarImage.fillAmount = Mathf.Clamp(publicvars.wood / publicvars.woodMax, 0, 1f);
    }
}
