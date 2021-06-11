using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float health; //vie de l'ennemi
    public HealthBar healthbar; // barre de vie de l'ennemi

    [SerializeField]
    private float armor; //resistance physique
    [SerializeField]
    private float magicRes;//resistance magique
    //resistances : 0 = 0% | 1 = 15% | 2 = 35% | 3 = 60%
    // -> pourquoi ne pas le stocker sous une forme de pourcentage au lieu de passer via des nombres?
    //    qqch comme 0.6 pour 60% de r�sistance magique
    [SerializeField]
    private float movSpeed; //vitesse de d�placement
    private int _killReward; //quantit� d'or donn�e � la mort
    private int _damage; //d�gats lorsqu'il sort de la carte

    private Vector3Int _target;

    private void Awake()
    {
        Enemies.addEnemy(gameObject);
    }

    private void Start()
    {
        generateEnemy();
    }

    //M�thode de g�n�ration : d�fini la premi�re case comme la StartTile, d�finie dans MapGenerator
    private void generateEnemy()
    {
        healthbar.SetMaxHealth((int)health);
        _target = MapGenerator.getStartCoords();
    }

    public void takeDamage(float dmg, int dmgType)
    {
        if (dmgType == 0)
        {
            dmg = armor switch
            {
                1 => (float) (dmg * 0.85),
                2 => (float) (dmg * 0.65),
                3 => (float) (dmg * 0.4),
                _ => dmg
            };
        }
        else if (dmgType == 1)
        {
            dmg = magicRes switch
            {
                1 => (float) (dmg * 0.85),
                2 => (float) (dmg * 0.65),
                3 => (float) (dmg * 0.4),
                _ => dmg
            };
        }
        health -= dmg;
        healthbar.SetHealth((int) health);

        if(health <= 0)
        {
            die();
        }
    }

    private void die()
    {
        Enemies.supressEnemy(gameObject);
        Destroy(this.transform.gameObject);
    }

    //D�place l'objet vers la case d�finie comme "objectif" (target)
    private void moveEnemy()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, _target, movSpeed * Time.deltaTime);
    }

    /* Update is called once per frame
     * v�rifie la position
     * d�place l'objet
     * */
    private void Update()
    {
        // checkPos();
        moveEnemy();
    }
}
