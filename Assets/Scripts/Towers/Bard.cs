using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bard : DefenseTowers
{
    private void Awake()
    {
        base.init("Barde", "Un barde tr?s joyeux qui joue de la musique du matin au soir", 0, 2, (float)0.5);
    }

    override
    protected  void shoot()
    {
        EnemyAI enemyAIScript = target.GetComponent<EnemyAI>();
        enemyAIScript.slow();

    }
}
