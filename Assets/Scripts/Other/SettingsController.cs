using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void backButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume",volume);
    }
}
