using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public int score_display;
    public float score;
    public float incr_by_second;
    [SerializeField] TextMeshProUGUI textbox;

    void Start()
    {
        score = 0f;
        incr_by_second = 0.2f; // currently 1 point per 5 seconds passed
    }

    void Update()
    {
        score += incr_by_second * Time.deltaTime;
        score_display = (int)score;
        textbox.text = "Score: " + score_display;
        PublicVars.thirst -= 0.2f;
        PublicVars.hunger -= 0.1f;
    }
}
