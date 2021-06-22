using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bard : DefenseTowers
{
    private void Awake()
    {
        base.init("Barde", "Un barde très joyeux qui joue de la musique du matin au soir", 0, 1, (float)1.5);
    }

    override
    protected  void shoot()
    {
        EnemyAI enemyAIScript = target.GetComponent<EnemyAI>();
        enemyAIScript.slow();

    }
}
