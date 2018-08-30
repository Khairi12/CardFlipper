using UnityEngine;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour {
    public static RewardManager rm;

    public int commonCount = 0;
    public int uncommonCount = 0;
    public int rareCount = 0;
    public int epicCount = 0;
    public int legendaryCount = 0;

    // Unity Scripts / component
    // Text scripts on gameobject will refresh its text display
    private Text commonText;
    private Text uncommonText;
    private Text rareText;
    private Text epicText;
    private Text legendaryText;
    
    private CardManager cm;

    // Built-in Unity method called when the game first initializes, called before Start()
    private void Awake() {
        rm = this;
    }

    // Built-in Unity method called whenever the game starts
    private void Start() {
        cm = CardManager.cm;

        commonCount = 0;
        uncommonCount = 0;
        rareCount = 0;
        epicCount = 0;
        legendaryCount = 0;

        // creates references to each specified gameobject's Text component attached to the children of each gameobject
        commonText = transform.Find("Common").GetChild(0).GetComponent<Text>();
        uncommonText = transform.Find("Uncommon").GetChild(0).GetComponent<Text>();
        rareText = transform.Find("Rare").GetChild(0).GetComponent<Text>();
        epicText = transform.Find("Epic").GetChild(0).GetComponent<Text>();
        legendaryText = transform.Find("Legendary").GetChild(0).GetComponent<Text>();

        CountCards();
        Refresh();
    }

    // Counts each cardType being used in the game
    public void CountCards()
    {
        foreach (GameObject card in cm.cards)
        {
            // gets the Card Script attached to the card object, then gets the cardType
            CardType cardType = card.GetComponent<Card>().cardType;

            AddCard(cardType);
        }
    }

    // add card to the list of rewardable cards, then refresh
    public void AddCard(CardType ct) {
        switch (ct) {
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

        Refresh();
    }

    // remove the card from the list of rewardable cards, then refresh
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

        Refresh();
    }
    
    // Updates the referenced text scripts and the text to display
    public void Refresh() {
        commonText.text = commonCount + "x";
        uncommonText.text = uncommonCount + "x";
        rareText.text = rareCount + "x";
        epicText.text = epicCount + "x";
        legendaryText.text = legendaryCount + "x";
    }

    // Reset the referenced text scripts, then update
    public void Clear() {
        commonCount = 0;
        uncommonCount = 0;
        rareCount = 0;
        epicCount = 0;
        legendaryCount = 0;

        Refresh();
    }
}
