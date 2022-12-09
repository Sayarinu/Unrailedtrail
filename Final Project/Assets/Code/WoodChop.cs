using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WoodChop : MonoBehaviour
{
    public AudioSource woodChopSound;
    public Image woodBarImage;
    public AudioSource enemyHitSound;

    [SerializeField] TextMeshProUGUI wood_text;

    public AudioClip woodChopClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wood_Resource")
        {
            PublicVars.wood += 5;
            if (PublicVars.wood > PublicVars.woodMax) {
                PublicVars.wood = PublicVars.woodMax;
            }
            woodChopSound.PlayOneShot(woodChopClip);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Weapon")
        {
            enemyHitSound.Play();
            // enemy.health --;
            // if (health <= 0) {
            PublicVars.hunger += 10; // when 
            Destroy(gameObject); // or reduce health
            // }
        }
    }

    public void Update() {
        UpdateWoodBar();
    }

    public void UpdateWoodBar()
    {
        woodBarImage.fillAmount = Mathf.Clamp(PublicVars.wood / PublicVars.woodMax, 0, 1f);
        wood_text.text = PublicVars.wood + "/" + PublicVars.woodMax;
    }
}