using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highscore;

    void Start() {
        highscore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    public void PlayGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
