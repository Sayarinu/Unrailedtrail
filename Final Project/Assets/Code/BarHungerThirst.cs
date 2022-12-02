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
