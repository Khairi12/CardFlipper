using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour {

    private RewardManager rm;
    private CardManager cm;
    private DrawManager dm;
    private InventoryManager im;

    private Button resetButton;

    private void Start() {
        rm = RewardManager.rm;
        cm = CardManager.cm;
        dm = DrawManager.dm;
        im = InventoryManager.im;

        resetButton = transform.GetChild(0).GetComponent<Button>();
        resetButton.onClick.AddListener(ResetButtonClick);
    }

    private void ResetButtonClick() {
        rm.Clear();
        dm.Clear();
        im.Clear();
        cm.Clear();

        cm.CreateCards();
        cm.CountCards();
    }
}
