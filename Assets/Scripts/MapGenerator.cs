using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //Variables
    public GameObject mapTile;
    [SerializeField] private int mapHauteur;
    [SerializeField] private int mapLargeur;

    public static List<GameObject> mapTiles = new List<GameObject>();
    public static List<GameObject> chemin = new List<GameObject>();
    private static GameObject startTile;
    private static GameObject endTile;


    private bool reachedX = false;
    private bool reachedY = false;

    private GameObject currentTile;
    private int currentIndex;
    private int nextIndex;

    //variable de couleur modifiable sur Unity
    public Color couleurChemin;

    //Méthode de lancement de la scène
    private void Start()
    {
        generateMap();
    }

    //Renvoie les cases de la ligne du haut
    private List<GameObject> getTopEdgeTiles()
    {
        List<GameObject> edgeTile = new List<GameObject>();

        for (int i = mapLargeur * (mapHauteur -1);  i < mapHauteur * mapLargeur; i++)
        {
            edgeTile.Add(mapTiles[i]);
        }

        return edgeTile;
    }

    //Renvoie les cases de la ligne du bas
    private List<GameObject> getBottomEdgeTiles()
    {
        List<GameObject> edgeTile = new List<GameObject>();

        for (int i = 0; i < mapLargeur * mapLargeur; i++)
        {
            edgeTile.Add(mapTiles[i]);
        }

        return edgeTile;
    }

    //Méthodes permettant de créer le chemin
    private void moveDown()
    {
        chemin.Add(currentTile);
        currentIndex = mapTiles.IndexOf(currentTile);
        nextIndex = currentIndex - mapLargeur;
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
    }

    public static GameObject getStartTile()
    {
        return startTile;
    }

    public static GameObject getEndTile()
    {
        return endTile;
    }

    /*Méthode principale :
     * Génère la map
     * Place le chemin
    */
    private void generateMap()
    {

        for (int y = 0 -(mapHauteur/2); y <mapHauteur - (mapHauteur / 2); y++)
        {
            for (int x = 0 - (mapLargeur / 2); x < mapLargeur - (mapLargeur / 2); x++)
            {
                GameObject newTile = Instantiate(mapTile);

                mapTiles.Add(newTile);

                newTile.transform.position = new Vector2(x,y);
            }
        }

        List<GameObject> topEdgeTiles = getTopEdgeTiles();
        List<GameObject> botEdgeTiles = getBottomEdgeTiles();



        int rand1 = Random.Range(0, mapLargeur - 1);
        int rand2 = Random.Range(0, mapLargeur - 1);

        startTile = topEdgeTiles[rand1];
        endTile = botEdgeTiles[rand2];

        currentTile = startTile;
        moveDown();
        int debugLoop = 0;

        while(reachedX == false)
        {
            debugLoop++;
            if(debugLoop > mapHauteur * mapLargeur)
            {
                Debug.Log("Boucle trop longue. Execution interrompue.");
                break;
            }
            if(currentTile.transform.position.x > endTile.transform.position.x)
            {
                moveLeft();
            }
            else if (currentTile.transform.position.x < endTile.transform.position.x)
            {
                moveRight();
            }
            else
            {
                reachedX = true;
            }
        }
        debugLoop = 0;
        while (reachedY == false)
        {
            debugLoop++;
            if (debugLoop > mapHauteur * mapLargeur)
            {
                Debug.Log("Boucle trop longue. Execution interrompue.");
                break;
            }

            if (currentTile.transform.position.y > endTile.transform.position.y)
            {
                moveDown();
            }
            else
            {
                reachedY = true;
            }

        }
        chemin.Add(endTile);
        foreach(GameObject obj in chemin)
        {
            obj.GetComponent<SpriteRenderer>().color = couleurChemin;
        }
    }
}
