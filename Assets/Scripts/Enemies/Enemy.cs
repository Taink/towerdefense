using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float health; //vie de l'ennemi
    [SerializeField]
    private float armor; //resistance physique
    [SerializeField]
    private float magicRes;//resistance magique
    //resistances : 0 = 0% | 1 = 15% | 2 = 35% | 3 = 60%
    [SerializeField]
    private float movSpeed; //vitesse de d�placement
    private int killReward; //quantit� d'or donn�e � la mort
    private int damage; //d�gats lorsqu'il sort de la carte

    private GameObject targetTile;


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
        targetTile = MapGenerator.getStartTile();
    }

    public void takeDamage(float dmg, int dmgType)
    {
        if (dmgType == 0)
        {
            switch (armor)
            {
                case 1:
                    dmg = (float)(dmg * 0.85);
                    break;
                case 2:
                    dmg = (float)(dmg * 0.65);
                    break;
                case 3:
                    dmg = (float)(dmg * 0.4);
                    break;
                default:
                    break;

            }
        }
        else if (dmgType == 1)
        {
            switch (magicRes)
            {
                case 1:
                    dmg = (float)(dmg * 0.85);
                    break;
                case 2:
                    dmg = (float)(dmg * 0.65);
                    break;
                case 3:
                    dmg = (float)(dmg * 0.4);
                    break;
                default:
                    break;

            }
        }
        health -= dmg;
        if(health<= 0)
        {
            die();
        }
    }

    private void die()
    {
        Enemies.supressEnemy(gameObject);
        Destroy(this.transform.gameObject);
    }

    //D�place l'objet vers la case d�finie comme "objectif" (targetTile)
    private void moveEnemy()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetTile.transform.position, movSpeed * Time.deltaTime);
    }
    
    //D�fini la case vers laquelle l'objet doit se diriger
    private void checkPos()
    {
        if (targetTile != null && targetTile != MapGenerator.getEndTile())
        {
            
            float distance = (this.transform.position - targetTile.transform.position).magnitude;
            if (distance < 0.001f)
            {
                int currentIndex = MapGenerator.getChemin().IndexOf(targetTile);
                targetTile = MapGenerator.getChemin()[currentIndex + 1];
                
            }

        }
    }

    /* Update is called once per frame
     * v�rifie la position
     * d�place l'objet
     * */
    private void Update()
    {
        checkPos();
        moveEnemy();
    }
}