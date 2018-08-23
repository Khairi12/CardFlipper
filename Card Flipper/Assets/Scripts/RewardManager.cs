using UnityEngine;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour {
    public static RewardManager rm;

    private CardManager cm;
    private Text commonText;
    private Text uncommonText;
    private Text rareText;
    private Text epicText;
    private Text legendaryText;

    private void Awake() {
        rm = this;
    }

    private void Start() {
        cm = CardManager.cm;

        commonText = transform.Find("Common").GetChild(0).GetComponent<Text>();
        uncommonText = transform.Find("Uncommon").GetChild(0).GetComponent<Text>();
        rareText = transform.Find("Rare").GetChild(0).GetComponent<Text>();
        epicText = transform.Find("Epic").GetChild(0).GetComponent<Text>();
        legendaryText = transform.Find("Legendary").GetChild(0).GetComponent<Text>();
    }

    public void UpdateDisplay() {
        commonText.text = cm.commonCount + "x";
        uncommonText.text = cm.uncommonCount + "x";
        rareText.text = cm.rareCount + "x";
        epicText.text = cm.epicCount + "x";
        legendaryText.text = cm.legendaryCount + "x";
    }

}
