using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject mapTile;
    [SerializeField] private int mapHauteur;
    [SerializeField] private int mapLargeur;

    private List<GameObject> mapTiles = new List<GameObject>();
    private List<GameObject> chemin = new List<GameObject>();


    private void Start()
    {
        generateMap();
    }
    private void generateMap()
    {

        for (int y = 0; y <mapHauteur; y++)
        {
            for (int x = 0; x < mapLargeur; x++)
            {
                GameObject newTile = Instantiate(mapTile);

                mapTiles.Add(newTile);

                newTile.transform.position = new Vector2(x,y);
            }
        }

    }
}
