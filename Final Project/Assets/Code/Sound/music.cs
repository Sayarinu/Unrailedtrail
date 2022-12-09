using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class music : MonoBehaviour
{
    public AudioMixer mixer;

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
        // check if another music player exists
        if (FindObjectsOfType(GetType()).Length > 1) {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float volume) {
        mixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }
}
