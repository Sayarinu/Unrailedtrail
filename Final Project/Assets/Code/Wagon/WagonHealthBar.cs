using UnityEngine;
using UnityEngine.UI;
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
}
