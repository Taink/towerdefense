
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    const int MaxCardInHand = 5;
    int cardsInHand = 0;
    [SerializeField] private GameObject card1;
    [SerializeField] private GameObject card2;
    [SerializeField] private GameObject card3;
    [SerializeField] private GameObject card4;
    private List<GameObject> cardHand;

    [SerializeField] private List<GameObject> cardPlaces;
    [SerializeField] private GameObject placementManager;
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
        StartCoroutine(draw(MaxCardInHand));
    }

    IEnumerator draw(int nbCartes)
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < nbCartes; i++)
        {
            int rint = Random.Range(0, 100);
            if (rint >= 0 && rint <34)
            {
                GameObject.Instantiate(card1, cardPlaces[i].transform.position, Quaternion.identity).tag = "Card1";
            }
            else if (rint >= 34 && rint < 67)
            {
                GameObject.Instantiate(card2, cardPlaces[i].transform.position, Quaternion.identity).tag = "Card2";
            }
            else if (rint >= 67 && rint < 90)
            {
                GameObject.Instantiate(card3, cardPlaces[i].transform.position, Quaternion.identity).tag = "Card3";
            }
            else if (rint >= 90 && rint < 100)
            {
                GameObject.Instantiate(card4, cardPlaces[i].transform.position, Quaternion.identity).tag = "Card4";
            }
            cardsInHand++;
        }
    }

    public void draw1card()
    {
        for (int i= 0;i < cardPlaces.Count; i++)
        {
            Vector3 cardPos = cardPlaces[i].transform.position;
            Vector2 cardPos2D = new Vector2(cardPos.x, cardPos.y);
            RaycastHit2D hit = Physics2D.Raycast(cardPos2D, Vector2.zero);
            if (hit.collider == null || hit.collider.gameObject.tag.Substring(0, 4) != "Card")
            {
                int rint = Random.Range(0, 100);
                if (rint >= 0 && rint < 34)
                {
                    GameObject.Instantiate(card1, cardPlaces[i].transform.position, Quaternion.identity).tag = "Card1";
                }
                else if (rint >= 34 && rint < 67)
                {
                    GameObject.Instantiate(card2, cardPlaces[i].transform.position, Quaternion.identity).tag = "Card2";
                }
                else if (rint >= 67 && rint < 90)
                {
                    GameObject.Instantiate(card3, cardPlaces[i].transform.position, Quaternion.identity).tag = "Card3";
                }
                else if (rint >= 90 && rint < 100)
                {
                    GameObject.Instantiate(card4, cardPlaces[i].transform.position, Quaternion.identity).tag = "Card4";
                }
                cardsInHand++;
            }
            return;
        }
    }



    public void piocher()
    {
        StartCoroutine(draw(1));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null )
            {
                if(hit.collider.gameObject.tag.Substring(0, 4) == "Card")
                {
                    //Debug.Log(hit.collider.gameObject.tag);
                    Card cardScript = GameObject.FindGameObjectWithTag(hit.collider.gameObject.tag).GetComponent<Card>();
                    PlacementManager placementScript = GameObject.FindGameObjectWithTag("PlacementManager").GetComponent<PlacementManager>();
                    GameObject tower = cardScript.getUnit();
                    cardScript.setPlacement();
                    placementScript.startBuilding(tower, Time.time);
                    cardScript.setPlaced();
                    cardsInHand--;
                    //hit.collider.attachedRigidbody.AddForce(Vector2.up);
                }
                
            }
        }

    }
}
