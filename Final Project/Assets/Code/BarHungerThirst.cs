using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarHungerThirst : MonoBehaviour
{
    public Image hungerBarImage;
    public float hunger_decay = 5f; // reduces hunger and thirst by 5pt every 30sec
    public bool isDecaying = false;

    [SerializeField] TextMeshProUGUI hunger_text;

    public void UpdateHungerBar()
    {
        hungerBarImage.fillAmount = Mathf.Clamp(PublicVars.hunger / PublicVars.hungerMax, 0, 1f);
        hunger_text.text = PublicVars.hunger + "/" + PublicVars.hungerMax;
    }

    void Update()
    {
        UpdateHungerBar();
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

        isDecaying = false;
    }

}
