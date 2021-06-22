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
    public Transform barrel;
    public Transform pivot;
    public Transform target;

    protected void init(string unitName, string unitDesc,float dmg, float rng, float atkSp)
    {
        base.init(unitName, unitDesc);
        this.damage = dmg;
        this.range = rng;
        this.atkSpeed = atkSp;
    }

    // Start is called before the first frame update
    protected void Start()
    {
        nextTimeShoot = Time.time;
    }


    private void updateNearestEnemy()
    {
        Transform currentNearestEnemy = null;
        float distance = Mathf.Infinity;

        foreach (Transform enemy in Enemies.getEnemies())
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

    // Update is called once per frame
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
