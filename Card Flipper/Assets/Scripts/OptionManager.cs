using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour {

    private RewardManager rm;
    private CardManager cm;
    private DrawManager dm;
    private InventoryManager im;

    private Button resetButton;

    // Built-in Unity method called when the game first initializes, called before Start()
    private void Start() {
        rm = RewardManager.rm;
        cm = CardManager.cm;
        dm = DrawManager.dm;
        im = InventoryManager.im;

        // creates a reference to the Button component attached to the child of this gameobject
        resetButton = transform.GetChild(0).GetComponent<Button>();

        // sets the listener of the button to ResetButtonClick();
        resetButton.onClick.AddListener(ResetButtonClick);
    }

    private void ResetButtonClick() {
        rm.Clear();
        dm.Clear();
        im.Clear();
        cm.Clear();

        cm.CreateCards();
        rm.CountCards();
    }
}
