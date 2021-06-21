using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private string unitName;
    //[SerializeField] GameObject unitée;
    [SerializeField] private GameObject unit;
    private bool inPlacement = false;
    private bool placed = false;

    public GameObject getUnit()
    {
        return unit;
        throw new NotImplementedException();
    }

    public void setPlacement()
    {
        inPlacement = true;
    }

    public void setPlaced()
    {
        inPlacement = false;
        placed = true;
    }


    private void Update()
    {

        if (placed)
        {
            Destroy(gameObject);
        }
        /*if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                //hit.collider.attachedRigidbody.AddForce(Vector2.up);
            }
        }
*/
    }

    private void Start()
    {
        
    }


}
