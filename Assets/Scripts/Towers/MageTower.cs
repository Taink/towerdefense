using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageTower : DefenseTowers
{
    public MageTower(string name, string unitDesc, float dmg, float rng, float atkSp)
        : base("Mage", "Un mage ancien qui tire son �nergie de son �norme chapeau pointu", 25, 4, 2)
    {

    }


    private void Start() => base.Start();
}
