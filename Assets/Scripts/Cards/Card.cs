using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private string unitName;
    //[SerializeField] GameObject unitée;
    [SerializeField] Tower unit;


  

    private void OnMouseOver()
    {
        const string phrase = " est survolé";
        Debug.Log(unit.getName() + phrase);
    }

    private void OnMouseExit()
    {
        Debug.Log(unit.getName() + " n'est plus survolé");   
    }


}
