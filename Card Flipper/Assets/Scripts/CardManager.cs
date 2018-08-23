using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {
    public static CardManager cm;
    public int cardAmount;

    private List<GameObject> cards = new List<GameObject>();
    private RewardManager rm;
    private GameObject commonCard;
    private GameObject uncommonCard;
    private GameObject rareCard;
    private GameObject epicCard;
    private GameObject legendaryCard;

    private void Awake() {
        cm = this;
    }

    private void Start() {
        rm = RewardManager.rm;

        commonCard = Resources.Load("CommonCard") as GameObject;
        uncommonCard = Resources.Load("UncommonCard") as GameObject;
        rareCard = Resources.Load("RareCard") as GameObject;
        epicCard = Resources.Load("EpicCard") as GameObject;
        legendaryCard = Resources.Load("LegendaryCard") as GameObject;

        CreateCards();
        CountCards();
    }

    private GameObject SelectCardType() {
        int value = Random.Range(0, 100);

        if (value < 1) {
            return legendaryCard;
        }
        else if (value < 5) {
            return epicCard;
        }
        else if (value < 30) {
            return rareCard;
        }
        else if (value < 50) {
            return uncommonCard;
        }
        else {
            return commonCard;
        }
    }

    public void CreateCards() {
        for (int i = 0; i < cardAmount; i++) {
            GameObject card = SelectCardType();
            cards.Add(card);
            Instantiate(card, transform);
        }
    }

    public void CountCards() {
        foreach (GameObject card in cards) {
            rm.AddCard(card.GetComponent<Card>().cardType);
        }
    }

    public void Clear() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }

        cards.Clear();
    }

}