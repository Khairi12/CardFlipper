using UnityEngine;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour
{
    private Text commonText;
    private Text uncommonText;
    private Text rareText;
    private Text epicText;
    private Text legendaryText;

	void Start () {
        commonText = transform.Find("Common").GetChild(0).GetComponent<Text>();
        uncommonText = transform.Find("Uncommon").GetChild(0).GetComponent<Text>();
        rareText = transform.Find("Rare").GetChild(0).GetComponent<Text>();
        epicText = transform.Find("Epic").GetChild(0).GetComponent<Text>();
        legendaryText = transform.Find("Legendary").GetChild(0).GetComponent<Text>();
    }
	
	void Update () {
		
	}
}
