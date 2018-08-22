using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{

    public int cardAmount;

    GameObject card;
    List<GameObject> cards = new List<GameObject>();

    void Start()
    {
        card = Resources.Load("Card") as GameObject;
        CreateCards();
    }

    void CreateCards()
    {
        for (int i = 0; i < cardAmount; i++)
        {
            cards.Add(Instantiate(card, transform));
        }
    }

}