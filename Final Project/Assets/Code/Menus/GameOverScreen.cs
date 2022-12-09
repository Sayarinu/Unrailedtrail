using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highscore;
    [SerializeField] TextMeshProUGUI score;

    void Start() {
        if (PublicVars.score > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", (int)PublicVars.score);
        }
        highscore.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        score.text = "Score: " + (int)PublicVars.score;
    }

    public void playAgain() {
        SceneManager.LoadScene("SampleScene");
    }
    public void returnToTitle() {
        SceneManager.LoadScene("Title Screen");
    }
    public void quit() {
        Application.Quit();
    }

}
