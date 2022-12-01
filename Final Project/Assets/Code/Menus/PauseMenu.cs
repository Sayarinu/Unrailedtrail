using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            goToState();
        }
    }

    public void goToState() {
        if (GameIsPaused) {
            Resume();
        } else {                
            Pause();
        }
    }

    void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = true;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ReturnToTile() {
        SceneManager.LoadScene("Title Screen");
    }

    public void Quit() {
        Application.Quit();
    }
}
