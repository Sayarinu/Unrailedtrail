using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WoodChop : MonoBehaviour
{
    public PublicVars publicvars = new PublicVars();
    public AudioSource woodChopSound;
    public Image woodBarImage;
    [SerializeField] TextMeshProUGUI wood_text;

    public AudioClip woodChopClip;

    private void OnTriggerEnter(Collider other)
    {
        print("collided");
        print(other.gameObject.tag);
        if (other.gameObject.tag == "Wood_Resource")
        {
            while(publicvars.wood < publicvars.woodMax)
            {
                publicvars.wood++;
                UpdateWoodBar();
            }
            woodChopSound.PlayOneShot(woodChopClip);
            Destroy(other.gameObject);
        }
    }

    public void UpdateWoodBar()
    {
        woodBarImage.fillAmount = Mathf.Clamp(publicvars.wood / publicvars.woodMax, 0, 1f);
        wood_text.text = publicvars.wood + "/" + publicvars.woodMax;
    }

}
