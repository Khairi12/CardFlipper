using UnityEngine;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour {
    public static RewardManager rm;

    public int commonCount = 0;
    public int uncommonCount = 0;
    public int rareCount = 0;
    public int epicCount = 0;
    public int legendaryCount = 0;
    
    private Text commonText;
    private Text uncommonText;
    private Text rareText;
    private Text epicText;
    private Text legendaryText;

    private void Awake() {
        rm = this;
    }

    private void Start() {
        commonCount = 0;
        uncommonCount = 0;
        rareCount = 0;
        epicCount = 0;
        legendaryCount = 0;

        commonText = transform.Find("Common").GetChild(0).GetComponent<Text>();
        uncommonText = transform.Find("Uncommon").GetChild(0).GetComponent<Text>();
        rareText = transform.Find("Rare").GetChild(0).GetComponent<Text>();
        epicText = transform.Find("Epic").GetChild(0).GetComponent<Text>();
        legendaryText = transform.Find("Legendary").GetChild(0).GetComponent<Text>();

        UpdateDisplay();
    }

    public void AddCard(CardType ct) {
        switch (ct)
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

        UpdateDisplay();
    }

    public void RemoveCard(CardType ct) {
        switch (ct)
        {
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

        UpdateDisplay();
    }

    public void UpdateDisplay() {
        commonText.text = commonCount + "x";
        uncommonText.text = uncommonCount + "x";
        rareText.text = rareCount + "x";
        epicText.text = epicCount + "x";
        legendaryText.text = legendaryCount + "x";
    }

    public void Clear() {
        commonCount = 0;
        uncommonCount = 0;
        rareCount = 0;
        epicCount = 0;
        legendaryCount = 0;

        UpdateDisplay();
    }
}
