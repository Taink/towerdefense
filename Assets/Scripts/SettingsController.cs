using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{

    public void backButton()
    {
        SceneManager.LoadScene("Menu");
    }


}
