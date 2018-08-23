using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    public static InventoryManager im;

    public int commonOwned = 0;
    public int uncommonOwned = 0;
    public int rareOwned = 0;
    public int epicOwned = 0;
    public int legendaryOwned = 0;

    private Text commonOwnedText;
    private Text uncommonOwnedText;
    private Text rareOwnedText;
    private Text epicOwnedText;
    private Text legendaryOwnedText;

    private void Awake() {
        im = this;
    }

    private void Start() {
        commonOwned = 0;
        uncommonOwned = 0;
        rareOwned = 0;
        epicOwned = 0;
        legendaryOwned = 0;

        commonOwnedText = transform.GetChild(0).Find("Common Card").GetChild(1).GetComponent<Text>();
        uncommonOwnedText = transform.GetChild(0).Find("Uncommon Card").GetChild(1).GetComponent<Text>();
        rareOwnedText = transform.GetChild(0).Find("Rare Card").GetChild(1).GetComponent<Text>();
        epicOwnedText = transform.GetChild(0).Find("Epic Card").GetChild(1).GetComponent<Text>();
        legendaryOwnedText = transform.GetChild(0).Find("Legendary Card").GetChild(1).GetComponent<Text>();
    }

    public void AddCard(CardType ct) {
        switch (ct)
        {
            case CardType.Common:
                commonOwned += 1;
                break;
            case CardType.Uncommon:
                uncommonOwned += 1;
                break;
            case CardType.Rare:
                rareOwned += 1;
                break;
            case CardType.Epic:
                epicOwned += 1;
                break;
            case CardType.Legendary:
                legendaryOwned += 1;
                break;
            default:
                break;
        }

        UpdateDisplay();
    }

    public void UpdateDisplay() {
        commonOwnedText.text = commonOwned + "x";
        uncommonOwnedText.text = uncommonOwned + "x";
        rareOwnedText.text = rareOwned + "x";
        epicOwnedText.text = epicOwned + "x";
        legendaryOwnedText.text = legendaryOwned + "x";
    }

    public void Clear() {
        commonOwned = 0;
        uncommonOwned = 0;
        rareOwned = 0;
        epicOwned = 0;
        legendaryOwned = 0;
        UpdateDisplay();
    }
}
