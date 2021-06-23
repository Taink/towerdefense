using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControllerScript : MonoBehaviour
{
    [SerializeField] private GameObject title1;
    [SerializeField] private GameObject title2;

    public void play()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void option()
    {
        SceneManager.LoadScene("LeSettingsScene");
    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.F))
        {
            title1.GetComponent<TMPro.TextMeshProUGUI>().text = "PIECE JOINTE SAINSON 4";
            title2.GetComponent<TMPro.TextMeshProUGUI>().text = "EB";
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            title1.GetComponent<TMPro.TextMeshProUGUI>().text = "GRAVE MISTAKE";
            title2.GetComponent<TMPro.TextMeshProUGUI>().text = "TD";
        }
    }

    public void exitApp()
    {
        Application.Quit();
    }
}
