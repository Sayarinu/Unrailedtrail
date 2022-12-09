using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    public int score_display;
    // public float score;
    public float incr_by_second;
    [SerializeField] TextMeshProUGUI textbox;

    void Start()
    {
        PublicVars.score = 0f;
        incr_by_second = 0.5f; // currently 1 point per 2 seconds passed
    }

    void FixedUpdate()
    {
        PublicVars.score += incr_by_second * Time.deltaTime;
        score_display = (int)PublicVars.score;
        textbox.text = "Score: " + score_display;
        if (PublicVars.score > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", (int)PublicVars.score);
        }
    }
}
