using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private int dmgType; // 0 = physique | 1 = magique | 2 ou autre = dégats bruts
    public GameObject target;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        dmgEnemy();
    }
    private void Update()
    {
        transform.position += transform.right * 0.085f;
    }

    public void updateTarget(GameObject target)
    {
        this.target = target;
    }
    public void dmgEnemy()
    {
        EnemyAI enemyAIScript = target.GetComponent<EnemyAI>();
        enemyAIScript.takeDamage(damage, dmgType);
    }

}
