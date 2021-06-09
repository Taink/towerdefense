using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    const int MaxCardInHand = 5;
    [SerializeField] private GameObject card1;
    [SerializeField] private GameObject card2;
    private List<GameObject> cardHand;
    [SerializeField] private List<GameObject> cardPlaces;
    // Start is called before the first frame update
    void Start()
    {

        //Vector3 vec = cardPlaces[1].transform.position;

        /*for (int i = 0; i<MaxCardInHand; i++)
        {
            if (Random.Range(0, 1) == 0)
            {
                cardHand.Add(card1);
            }
            else
            {
                cardHand.Add(card2);
            }
        }*/

        for (int i = 0; i < MaxCardInHand; i++)
        {
            Instantiate(card1, cardPlaces[i].transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
