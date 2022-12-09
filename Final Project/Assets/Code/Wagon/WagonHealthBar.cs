using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WagonHealthBar : MonoBehaviour
{
    public Image healthBarImage;
    [SerializeField] TextMeshProUGUI hp_text;

    public void Start() {
        PublicVars.health = 100;
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp(PublicVars.health / PublicVars.maxHealth, 0, 1f);
        hp_text.text = PublicVars.health + "/" + PublicVars.maxHealth;
    }

    public void Update() {
        EndGame();
    }

    public void EndGame() {
        if (PublicVars.health == 0 || PublicVars.hunger == 0) {
            PublicVars.hunger = 100;
            PublicVars.health = 100;
            PublicVars.wood = 5;
            SceneManager.LoadScene("GameOver");
        }
    }
}
