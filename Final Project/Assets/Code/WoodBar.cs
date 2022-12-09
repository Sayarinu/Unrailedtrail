using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WoodBar : MonoBehaviour
{
    public Image woodBarImage;
    [SerializeField] TextMeshProUGUI wood_text;

    public void Update() {
        UpdateWoodBar();
    }

    public void UpdateWoodBar()
    {
        woodBarImage.fillAmount = Mathf.Clamp(PublicVars.wood / PublicVars.woodMax, 0, 1f);
        wood_text.text = PublicVars.wood + "/" + PublicVars.woodMax;
    }
}