using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour
{
    public GameObject basicEnemy;
    public GameObject dogEnemy;
    public GameObject mageEnemy;
    public GameObject tankEnemy;

    private const float basicTime = (float)0.75;
    private const float dogTime = (float)0.50;
    private const float mageTime = (float)1.25;
    private const float tankTime = (float)1.25;

    public float timeBetweenWaves;
    public float timeBeforeRoundStart;
    private float timeVariable;
    public int round;
    private int lastRound;
    private int power = 2;
    private int compteur;
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
        lastRound = 10;
        updateRound();
    }



    private void spawnEnemies()
    {
        compteur = 0;
        power = power + 3;
        if(round < 5)
        {
            StartCoroutine(ISpawnEnemies(5, basicEnemy, basicTime));
            compteur += 5;
        }
        if (round >= 3 & round < 5)
        {
            StartCoroutine(ISpawnEnemies((round-2)*2, dogEnemy, dogTime));
            compteur++;
        }
        if (round >=5 )
        {
            power++;
            while (compteur < power)
            {
                int rint = Random.Range(0, 4);
                switch (rint)
                {
                    case 0:
                        StartCoroutine(ISpawnEnemies(2, basicEnemy, basicTime));
                        compteur += 2;
                        break;
                    case 1:
                        StartCoroutine(ISpawnEnemies(2, dogEnemy, dogTime));
                        compteur += 2;
                        break;
                    case 2:
                        StartCoroutine(ISpawnEnemies(2, mageEnemy, mageTime));
                        compteur += 4;
                        break;
                    case 3:
                        StartCoroutine(ISpawnEnemies(2, tankEnemy, tankTime));
                        compteur += 4;
                        break;


                }
            }
        }

        StartCoroutine(ISpawnEnemies(power - compteur, basicEnemy, (float)0.5));

    }

    IEnumerator ISpawnEnemies(int nb, GameObject enemy, float time) //nombre d'ennemis, type, temps entre chaque spawn
    {
        for(int i = 0; i < nb; i++)
        {
            GameObject newEnemy = Instantiate(enemy, Enemies.Start.position, Quaternion.identity);
            yield return new WaitForSeconds(time);
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
