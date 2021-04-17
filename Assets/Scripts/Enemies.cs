using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private static List<GameObject> enemies = new List<GameObject>();

    public static List<GameObject> getEnemies()
    {
        return enemies;
    }

    public static void addEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    public static void supressEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

}
