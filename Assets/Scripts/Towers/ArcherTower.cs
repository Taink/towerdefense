using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : DefenseTowers
{

    public ArcherTower(string name, string unitDesc, float dmg, float rng, float atkSp)
        : base("Archer", "Un elfe aux longues oreilles qui est passionn� de la fl�che. A chaque tir r�ussi, il crie 'LEZGONGE'.", 15,4,1)
    {
        
    }


    private void Start() => base.Start();
}
