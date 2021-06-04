using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : DefenseTowers
{

    public ArcherTower(string name, string unitDesc, float dmg, float rng, float atkSp)
        : base("Archer", "Un elfe aux longues oreilles qui est passionné de la flèche. A chaque tir réussi, il crie 'LEZGONGE'.", 15,4,1)
    {
        
    }


    private void Start() => base.Start();
}
