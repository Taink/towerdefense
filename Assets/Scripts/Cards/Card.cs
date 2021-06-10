using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private string unitName;
    //[SerializeField] GameObject unitée;
    [SerializeField] Tower unit;



    private void Update()
    {


        if (Input.GetMouseButtonDown(0))
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

    }

    private void Start()
    {
        
    }


}
