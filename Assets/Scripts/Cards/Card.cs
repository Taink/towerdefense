using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private string unitName;
    //[SerializeField] GameObject unit�e;
    [SerializeField] Tower unit;


    public Card()
    {
        //unitName = unit.name;
    }

    private void OnMouseOver()
    {
        Debug.Log(unitName + " est survol�");
    }

    private void OnMouseExit()
    {
        Debug.Log(unitName + " n'est plus survol�");   
    }


}
