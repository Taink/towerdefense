using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public GameObject basicTowerObject;
    private GameObject dummyPlacement;
    public Camera cam;
    private GameObject hoverTile;

    public LayerMask mask;
    public LayerMask towerMask;
    public bool isBuilding;



    public void Start()
    {
        startBuilding();
    }

    public Vector2 getMousePos()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void getHoverTile()
    {
        Vector2 mousePos = getMousePos();

        RaycastHit2D hit = Physics2D.Raycast(mousePos, new Vector2(0, 0), 0.1f, mask, -100, 100);

        if (hit.collider != null)
        {
            hoverTile = hit.collider.gameObject;
        }
    }


    public bool checkTower()
    {
        bool towerOnSlot = false;
        Vector2 mousePos = getMousePos();
        RaycastHit2D hit = Physics2D.Raycast(mousePos, new Vector2(0, 0), 0.1f, towerMask, -100, 100);

        if(hit.collider != null)
        {
            towerOnSlot = true;
        }

        return towerOnSlot;
    }
    public void placeBuilding()
    {
        if (hoverTile != null & !checkTower())
        {
            GameObject newTowerObject = Instantiate(basicTowerObject);
            newTowerObject.layer = LayerMask.NameToLayer("Tower");
            newTowerObject.transform.position = hoverTile.transform.position;
            endBuilding();
        }    
    }

    public void startBuilding()
    {
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
        if(dummyPlacement != null)
        {
            Destroy(dummyPlacement);
        }
    }

    public void Update()
    {
        
        if (isBuilding == true)
        {
            if(dummyPlacement != null)
            {
                getHoverTile();
                if(hoverTile != null)
                {
                    dummyPlacement.transform.position = hoverTile.transform.position;
                }
            }
            if (Input.GetButtonDown("Fire1"))
            {
                placeBuilding();
            }
            
        }
    }

}
