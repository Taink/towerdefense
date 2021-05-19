using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : Tower
{
    public GameObject arrow;
    public Transform barrel;
    public Transform pivot;
    protected override void shoot()
    {
        base.shoot();
        GameObject newArrow = Instantiate(arrow, barrel.position, pivot.rotation);
        
    }

}
