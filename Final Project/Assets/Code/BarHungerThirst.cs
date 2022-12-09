using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarHungerThirst : MonoBehaviour
{
    public Image hungerBarImage;
    public Image thirstBarImage;

    public float hunger_decay = 5f; // reduces hunger and thirst by 5pt every 30sec
    public float thirst_decay = 5f;
    public bool isDecaying = false;

    [SerializeField] TextMeshProUGUI hunger_text;
    [SerializeField] TextMeshProUGUI thirst_text;

    public void UpdateHungerBar()
    {
        hungerBarImage.fillAmount = Mathf.Clamp(PublicVars.hunger / PublicVars.hungerMax, 0, 1f);
        hunger_text.text = PublicVars.hunger + "/" + PublicVars.hungerMax;
    }

    public void UpdateThirstBar()
    {
        thirstBarImage.fillAmount = Mathf.Clamp(PublicVars.thirst / PublicVars.thirstMax, 0, 1f);
        thirst_text.text = PublicVars.thirst + "/" + PublicVars.thirstMax;
    }

    void Update()
    {
        if (isDecaying == false)
        {
            isDecaying = true;
            StartCoroutine(Decay(20));
        }
    }

    IEnumerator Decay(int time)
    {
        yield return new WaitForSeconds(time); // waits 20 secs to decay hunger/thirst 

        PublicVars.hunger -= hunger_decay; 
        UpdateHungerBar();

        PublicVars.thirst -= thirst_decay;
        UpdateThirstBar();

        isDecaying = false;
    }

}
