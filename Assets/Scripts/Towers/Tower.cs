using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    private string towerName;
    private string unitDescription;

    public Tower(string unitName, string desc)
    {
        this.towerName = name;
        this.unitDescription = desc;
    }

    public string getName()
    {
        return this.towerName;
    }

    public string getDescription()
    {
        return this.unitDescription;
    }
}
