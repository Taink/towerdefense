using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DefenseTowers : Tower
{
    private float damage;
    private float range;
    private float atkSpeed; // Temps en secondes entre chaque attaque 
    private float nextTimeShoot;

    [SerializeField] private GameObject bullet;
    private Transform barrel;
    private Transform pivot;
    public GameObject target;

    public DefenseTowers(string unitName, string unitDesc,float dmg, float rng, float atkSp)
        : base(unitName, unitDesc)
    {
        this.damage = dmg;
        this.range = rng;
        this.atkSpeed = atkSp;
    }

    // Start is called before the first frame update
    protected void Start()
    {
        nextTimeShoot = Time.time;
    }

    // Update is called once per frame
    private void updateNearestEnemy()
    {
        GameObject currentNearestEnemy = null;
        float distance = Mathf.Infinity;

        foreach (GameObject enemy in Enemies.getEnemies())
        {
            if (enemy != null)
            {
                float distanceCheck = (this.transform.position - enemy.transform.position).magnitude;
                if (distanceCheck < distance)
                {
                    distance = distanceCheck;
                    currentNearestEnemy = enemy;
                }
            }

        }

        if (distance <= range)
        {
            target = currentNearestEnemy;
        }
        else
        {
            target = null;
        }
    }

    protected virtual void shoot()
    {
        GameObject newBullet = Instantiate(bullet, barrel.position, pivot.rotation);
        Bullet bulletScript = newBullet.GetComponent<Bullet>();
        bulletScript.updateTarget(target);

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
