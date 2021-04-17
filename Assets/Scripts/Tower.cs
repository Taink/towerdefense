using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]private float range;
    [SerializeField] private float damage;
    [SerializeField] private float atkSpeed; // Temps en secondes entre chaque attaque 

    private float nextTimeShoot;

    private GameObject target;

    // Start is called before the first frame update
    private void Start()
    {
        nextTimeShoot = Time.time;
    }

    // Update is called once per frame
    private void updateNearestEnemy()
    {
        GameObject currentNearestEnemy = null;
        float distance = Mathf.Infinity;
        foreach(GameObject enemy in Enemies.getEnemies())
        {
            float distanceCheck = (this.transform.position - enemy.transform.position).magnitude;
            if(distanceCheck < distance)
            {
                distance = distanceCheck;
                currentNearestEnemy = enemy;
            }
        }

        if(distance <= range)
        {
            target = currentNearestEnemy;
        }
        else
        {
            target = null;
        }
    }

    private void shoot()
    {
            Enemy enemyScript = target.GetComponent<Enemy>();
            enemyScript.takeDamage(damage);

    }

    private void Update()
    {
        updateNearestEnemy();
        
        if (Time.time >= nextTimeShoot)
        {
            if (target != null)
            {
                shoot();
                nextTimeShoot = Time.time + atkSpeed;
            }    
        }
    }
}
