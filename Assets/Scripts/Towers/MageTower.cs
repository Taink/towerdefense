using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageTower : DefenseTowers
{
 
    private void Awake()
    {
        base.init("Mage", "Un mage ancien qui tire son �nergie de son �norme chapeau pointu", 25, 4, 2);
    }

    private void Start() => base.Start();
}
