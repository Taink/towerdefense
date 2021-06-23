using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlacementGenerator : MonoBehaviour
{
    public Transform start;
    public Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        Enemies.Start = start;
        Enemies.Target = target;
    }
}
