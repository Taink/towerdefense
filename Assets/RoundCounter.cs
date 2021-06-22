using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{
    private static Text roundText;

    void Start()
    {
        roundText = GetComponent<Text>();
    }
    public static void updateRound(int round, int lastRound)
    {
        roundText.text = "Vague " + round + "/" + lastRound;
    }
}
