using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {
    public int cardAmount;
    public static int cardDraws;

    private List<GameObject> cards = new List<GameObject>();

    private GameObject commonCard;
    private GameObject uncommonCard;
    private GameObject rareCard;
    private GameObject epicCard;
    private GameObject legendaryCard;

    private int commonCount = 0;
    private int uncommonCount = 0;
    private int rareCount = 0;
    private int epicCount = 0;
    private int legendaryCount = 0;

    private void Start() {
        commonCard = Resources.Load("CommonCard") as GameObject;
        uncommonCard = Resources.Load("UncommonCard") as GameObject;
        rareCard = Resources.Load("RareCard") as GameObject;
        epicCard = Resources.Load("EpicCard") as GameObject;
        legendaryCard = Resources.Load("LegendaryCard") as GameObject;
        cardDraws = 3;

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

    private void CreateCards() {
        for (int i = 0; i < cardAmount; i++) {
            cards.Add(SelectCardType());
        }
    }

    private void CountCards() {
        foreach (GameObject card in cards) {
            switch (card.GetComponent<Card>().cardType)
            {
                case CardType.Common:
                    commonCount += 1;
                    break;
                case CardType.Uncommon:
                    uncommonCount += 1;
                    break;
                case CardType.Rare:
                    rareCount += 1;
                    break;
                case CardType.Epic:
                    epicCount += 1;
                    break;
                case CardType.Legendary:
                    legendaryCount += 1;
                    break;
                default:
                    break;
            }
        }
    }

}