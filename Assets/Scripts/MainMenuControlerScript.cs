using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControlerScript : MonoBehaviour
{
   public void play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void option()
    {
        //to option scene here
    }

    public void exitApp()
    {
        Application.Quit();
    }

}
