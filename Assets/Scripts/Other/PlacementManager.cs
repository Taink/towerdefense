using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlacementManager : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    
    private GameObject dummyPlacement;
    public Camera cam;
    private Vector3? hoverTilePos;

    public LayerMask mask;
    public LayerMask towerMask;
    public bool isBuilding;
    public GameObject basicTowerObject;
    private float time;

    public void Start()
    {
        //startBuilding();
    }

    public Vector2 getMousePos()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }


    public bool checkTower()
    {
        bool towerOnSlot = false;
        Vector2 mousePos = getMousePos();
        RaycastHit2D hit = Physics2D.Raycast(mousePos, new Vector2(0, 0), 0.1f, towerMask, -100, 100);

        if(hit.collider)
        {
            towerOnSlot = true;
        }

        return towerOnSlot;
    }
    public void placeBuilding()
    {
        if (hoverTilePos != null && !checkTower())
        {
            GameObject newTowerObject = Instantiate(basicTowerObject);
            newTowerObject.layer = LayerMask.NameToLayer("Tower");
            if (hoverTilePos != null) newTowerObject.transform.position = (Vector3) hoverTilePos;
            endBuilding();
        }    
    }

    public void startBuilding(GameObject tower, float t)
    {
        time = t;
        basicTowerObject = tower;
        isBuilding = true;

        dummyPlacement = Instantiate(basicTowerObject);

        if(dummyPlacement.GetComponent<Tower>() != null)
        {
            Destroy(dummyPlacement.GetComponent<Tower>());
        }
        if (dummyPlacement.GetComponent<Rotation>() != null)
        {
            Destroy(dummyPlacement.GetComponent<Rotation>());
        }
       
    }


    public void endBuilding()
    {
        isBuilding = false;
        if(dummyPlacement)
        {
            Destroy(dummyPlacement);
        }
    }

    public void Update()
    {
        
        if (isBuilding == true)
        {
            if(dummyPlacement)
            {
                var mousePos = getMousePos();

                var tileCoords = new Vector3Int((int) mousePos.x, (int) mousePos.y, 0);
                var tile = tilemap.GetTile<TerrainTile>(tileCoords);

                if(tile && !tile.flags.Contains(TerrainData.Restricted))
                {
                    hoverTilePos = tileCoords;
                    if (hoverTilePos != null) dummyPlacement.transform.position = (Vector3) hoverTilePos;
                }
                else
                {
                    hoverTilePos = null;
                }
            }
            if (Input.GetMouseButtonDown(0) & Time.time - time > 0.01)
            {
                placeBuilding();
            }
            
        }
    }

}
