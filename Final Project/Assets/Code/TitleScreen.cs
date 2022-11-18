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
}
