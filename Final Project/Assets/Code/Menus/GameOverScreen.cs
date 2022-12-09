using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
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
