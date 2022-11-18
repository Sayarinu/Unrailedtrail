using UnityEngine;
using UnityEngine.UI;

public class WagonHealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public Wagon wagon;

    public void UpdateHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp(wagon.health / wagon.maxHealth, 0, 1f);
    }
}
