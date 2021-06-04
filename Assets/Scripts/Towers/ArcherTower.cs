using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : DefenseTowers
{

    private void Awake()
    {
        base.init("Archer", "Un elfe aux longues oreilles qui est passionné de la flèche. A chaque tir réussi, il crie 'LEZGONGE'.", 15, 4, 1);
    }

    private void Start() => base.Start();
}
