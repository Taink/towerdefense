using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    //Variables
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tile defaultTile;
    [SerializeField] private int mapHeight;
    [SerializeField] private int mapWidth;

    private static Vector3Int startCoords;
    private static Vector3Int endCoords;

    //variable de couleur modifiable sur Unity
    public Color couleurChemin;

    //M�thode de lancement de la sc�ne
    private void Start()
    {
        generateMap();
    }

    /*//M�thodes permettant de cr�er le chemin
    private void moveDown()
    {
        chemin.Add(currentTile);
        currentIndex = mapTiles.IndexOf(currentTile);
        nextIndex = currentIndex - mapWidth;
        currentTile = mapTiles[nextIndex];
    }

    private void moveLeft()
    {
        chemin.Add(currentTile);
        currentIndex = mapTiles.IndexOf(currentTile);
        nextIndex = currentIndex-1;
        currentTile = mapTiles[nextIndex];
    }

    private void moveRight()
    {
        chemin.Add(currentTile);
        currentIndex = mapTiles.IndexOf(currentTile);
        nextIndex = currentIndex+1;
        currentTile = mapTiles[nextIndex];
    }

    public static List<GameObject> getMap()
    {
        return mapTiles;
    }

    public static List<GameObject> getChemin()
    {
        return chemin;
    }*/

    public static Vector3Int getStartCoords()
    {
        return startCoords;
    }

    public static Vector3Int getEndCoords()
    {
        return endCoords;
    }

    /*M�thode principale :
     * G�n�re un rectangle correspondant aux dimensions
     * G�n�re un d�part et une arriv�e
    */
    private void generateMap()
    {
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), defaultTile);
            }
        }

        startCoords = new Vector3Int(Random.Range(0, mapWidth - 1), 0, 0);
        endCoords = new Vector3Int(Random.Range(0, mapWidth - 1), mapHeight - 1, 0);
    }
}
