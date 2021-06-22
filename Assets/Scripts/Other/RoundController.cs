using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour
{
    public GameObject basicEnemy;

    public float timeBetweenWaves;
    public float timeBeforeRoundStart;
    private float timeVariable;
    public int round;
    private int lastRound;
    public Text roundText;

    private bool isRoundGoing;
    private bool isIntermission;
    private bool isStart;

    private void Start()
    {
        isRoundGoing = false;
        isIntermission = false;
        isStart = true;

        timeVariable = Time.time + timeBeforeRoundStart;
        round = 1;
        lastRound = 20;
        updateRound();
    }


    private void spawnEnemies()
    {
        StartCoroutine("ISpawnEnemies");
    }

    IEnumerator ISpawnEnemies()
    {
        for(int i = 0; i < round; i++)
        {
            GameObject newEnemy = Instantiate(basicEnemy, MapGenerator.getStartCoords(), Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }

    private void Update()
    {
        if (isStart & Time.time >= timeVariable)
        {
            isStart = false;
            isRoundGoing = true;

            spawnEnemies();
            return;
        }
        else if (isIntermission & Time.time >= timeVariable) 
        {
            isIntermission = false;
            isRoundGoing = true;

            spawnEnemies();
            return;

        }
        else if (isRoundGoing)
        {
            if (Enemies.getEnemies().Length > 0)
            {

            }
            else
            {
                isIntermission = true;
                isRoundGoing = false;

                timeVariable = Time.time + timeBeforeRoundStart;
                round++;
                updateRound();
                return;
            }
        }
    }
    public void updateRound()
    {
        roundText.text = "Vague " + round + "/" + lastRound;
    }
}
