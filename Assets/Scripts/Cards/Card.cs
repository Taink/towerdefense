using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private string unitName;
    //[SerializeField] GameObject unit�e;
    [SerializeField] Tower unit;


  

    private void OnMouseOver()
    {
        const string phrase = " est survol�";
        Debug.Log(unit.getName() + phrase);
    }

    private void OnMouseExit()
    {
        Debug.Log(unit.getName() + " n'est plus survol�");   
    }


}
