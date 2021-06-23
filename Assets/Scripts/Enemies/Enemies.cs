using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public static Transform Start;
    public static Transform Target;

    private static List<Transform> enemies;
    

    public static Transform[] getEnemies()
    {
        return enemies.ToArray();
    }

    public void Awake()
    {
        enemies = new List<Transform>();
    }


    public static void AddEnemy(Transform enemy)
    {
        // enemy.SetParent();
        enemies.Add(enemy);
    }

    public static void enemyKilled(Transform enemy, int reward)
    {
        RemoveEnemy(enemy);
        HandManager handScript = GameObject.FindGameObjectWithTag("HandManager").GetComponent<HandManager>();
        handScript.updateDrawBar(reward);
    }

    public static void RemoveEnemy(Transform enemy)
    {
        enemies.Remove(enemy);
    }

}
