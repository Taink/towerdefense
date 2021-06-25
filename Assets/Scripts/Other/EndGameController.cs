using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{

    public void Retour()
    {
        SceneManager.LoadScene("Menu");
    }

}
