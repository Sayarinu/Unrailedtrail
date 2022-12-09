using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WagonHealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public WagonDamageController wagon;
    [SerializeField] TextMeshProUGUI hp_text;

    public void UpdateHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp(wagon.health / wagon.maxHealth, 0, 1f);
        hp_text.text = wagon.health + "/" + wagon.maxHealth;
    }

    public void Update() {
        EndGame();
    }

    public void EndGame() {
        if (wagon.health == 0 || PublicVars.hunger == 0) {
            PublicVars.hunger = 100;
            wagon.health = 100;
            PublicVars.wood = 5;
            SceneManager.LoadScene("GameOver");
        }
    }
}
