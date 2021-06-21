using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour
{
    public static int remainingLives;
    private Text livesText;

    void Start()
    {
        livesText = GetComponent<Text>();
        remainingLives = 20;
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = remainingLives.ToString();
    }
}
