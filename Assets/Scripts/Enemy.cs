using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float health; //vie de l'ennemi

    [SerializeField]
    private float movSpeed; //vitesse de déplacement
    private int killReward; //quantité d'or donnée à la mort
    private int damage; //dégats lorsqu'il sort de la carte

    private GameObject targetTile;


    private void Awake()
    {
        Enemies.addEnemy(gameObject);
    }

    private void Start()
    {
        generateEnemy();
    }

    //Méthode de génération : défini la première case comme la StartTile, définie dans MapGenerator
    private void generateEnemy()
    {
        targetTile = MapGenerator.getStartTile();
    }

    public void takeDamage(float dmg)
    {
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

    //Déplace l'objet vers la case définie comme "objectif" (targetTile)
    private void moveEnemy()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetTile.transform.position, movSpeed * Time.deltaTime);
    }
    
    //Défini la case vers laquelle l'objet doit se diriger
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
     * vérifie la position
     * déplace l'objet
     * */
    private void Update()
    {
        checkPos();
        moveEnemy();
    }
}
