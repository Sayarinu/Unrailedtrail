using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChop : MonoBehaviour
{
    public PublicVars publicvars = new PublicVars();
    public AudioSource enemyHitSound;
    [SerializeField] private int foodAmt = 10;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            enemyHitSound.Play();
            // enemy.health --;
            // if (health <= 0) {
            publicvars.hunger += foodAmt; // when 
            Destroy(gameObject); // or reduce health
            // }
        }
//    public void UpdateFoodBar()
//    {
//        woodBarImage.fillAmount = Mathf.Clamp(publicvars.wood / publicvars.woodMax, 0, 1f);
//        wood_text.text = publicvars.wood + "/" + publicvars.woodMax;
//    }
    }  
}