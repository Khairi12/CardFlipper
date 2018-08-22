using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

    public int cardAmount;

    private GameObject commonCard;
    private GameObject uncommonCard;
    private GameObject rareCard;
    private GameObject epicCard;
    private GameObject legendaryCard;

    private List<GameObject> cards = new List<GameObject>();

    private void Start() {
        commonCard = Resources.Load("CommonCard") as GameObject;
        uncommonCard = Resources.Load("UncommonCard") as GameObject;
        rareCard = Resources.Load("RareCard") as GameObject;
        epicCard = Resources.Load("EpicCard") as GameObject;
        legendaryCard = Resources.Load("LegendaryCard") as GameObject;

        CreateCards();
    }

    private GameObject SelectCardType() {
        int value = Random.Range(0, 100);

        if (value < 1)
        {
            return legendaryCard;
        }
        else if (value < 5)
        {
            return epicCard;
        }
        else if (value < 30)
        {
            return rareCard;
        }
        else if (value < 50)
        {
            return uncommonCard;
        }
        else
        {
            return commonCard;
        }
    }

    private void CreateCards() {
        for (int i = 0; i < cardAmount; i++) {
            cards.Add(Instantiate(SelectCardType(), transform));
        }
    }

}