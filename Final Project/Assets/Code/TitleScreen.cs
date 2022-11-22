using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] string sceneName = "SampleScene";

    public void StartGame(){
        SceneManager.LoadScene(sceneName);
    }

    public void LoadCredits(){
        SceneManager.LoadScene("Credits");
    }

    public void LoadTitle(){
        SceneManager.LoadScene("Title Screen");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
