using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    //Variables
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase defaultTile;
    [SerializeField] private TileBase borderTile;
    [SerializeField] private int mapHeight;
    [SerializeField] private int mapWidth;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    private static Vector3Int startCoords;
    private static Vector3Int endCoords;

    //Méthode de lancement de la scène
    private void Start()
    {
        generateMap();
        SnapCamToGrid();
    }

    private void SnapCamToGrid()
    {
        var curPos = transform.position;
        cameraTransform.position = new Vector3(curPos.x + mapWidth / 2f, curPos.y + mapHeight / 2f, cameraTransform.position.z);
    }

    public static Vector3Int getStartCoords()
    {
        return startCoords;
    }

    public static Vector3Int getEndCoords()
    {
        return endCoords;
    }

    /*Méthode principale :
     * Génère un rectangle correspondant aux dimensions
     * Génère un départ et une arrivée
    */
    private void generateMap()
    {
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                if (x == 0 || y == 0 || x == mapWidth - 1 || y == mapHeight - 1)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), borderTile);
                    continue;
                }
                tilemap.SetTile(new Vector3Int(x, y, 0), defaultTile);
            }
        }

        startCoords = new Vector3Int(Random.Range(0, mapWidth - 1), mapHeight - 1, 0);
        endCoords = new Vector3Int(Random.Range(0, mapWidth - 1), 0, 0);

        startPoint.localPosition = startCoords;
        endPoint.localPosition = endCoords;
    }
}
