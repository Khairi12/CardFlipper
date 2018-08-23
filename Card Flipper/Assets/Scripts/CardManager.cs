using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {
    public static CardManager cm;
    public int cardAmount;
    public int commonCount = 0;
    public int uncommonCount = 0;
    public int rareCount = 0;
    public int epicCount = 0;
    public int legendaryCount = 0;

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

        commonCount = 0;
        uncommonCount = 0;
        rareCount = 0;
        epicCount = 0;
        legendaryCount = 0;

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
            GameObject card = SelectCardType();
            cards.Add(card);
            Instantiate(card, transform);
        }
    }

    private void CountCards() {
        foreach (GameObject card in cards) {
            switch (card.GetComponent<Card>().cardType) {
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

    public void RemoveCard(CardType ct) {
        switch (ct) {
            case CardType.Common:
                commonCount -= 1;
                break;
            case CardType.Uncommon:
                uncommonCount -= 1;
                break;
            case CardType.Rare:
                rareCount -= 1;
                break;
            case CardType.Epic:
                epicCount -= 1;
                break;
            case CardType.Legendary:
                legendaryCount -= 1;
                break;
            default:
                break;
        }

        rm.UpdateDisplay();
    }
}