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
        /*for (int i = 0; i < MaxCardInHand; i++)
        {
            Instantiate(card1, cardPlaces[i].transform.position, Quaternion.identity);
        }*/
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < MaxCardInHand; i++)
        {
            if (Random.Range(0, 2) == 0)
            {
                Instantiate(card1, cardPlaces[i].transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(card2, cardPlaces[i].transform.position, Quaternion.identity);
            }
            
        }
    }

    // Update is called once per frame
    void Update()
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
}
