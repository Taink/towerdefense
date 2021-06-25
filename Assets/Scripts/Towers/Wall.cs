using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Tower
{
    private void Awake()
    {
        base.init("Mur", "Un bon mur en pierre, bien solide !");
    }
}
