using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    const int MaxCardInHand = 5;
    [SerializeField] private GameObject card1;
    [SerializeField] private GameObject card2;
    private List<GameObject> cardHand;
    // Start is called before the first frame update
    void Start()
    {
        

        for (int i = 0; i<MaxCardInHand; i++)
        {
            if (Random.Range(0, 1) == 0)
            {
                cardHand.Add(card1);
            }
            else
            {
                cardHand.Add(card2);
            }
        }

        foreach (GameObject card in cardHand){
            Instantiate(card);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
