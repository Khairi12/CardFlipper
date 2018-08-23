using UnityEngine;
using UnityEngine.UI;

public class DrawManager : MonoBehaviour {
    public static DrawManager dm;
    public int drawCount;
    
    private Text drawCountText;
    
    private void Awake() {
        dm = this;
    }

    private void Start () {
        drawCount = 3;
        drawCountText = transform.GetChild(1).GetComponent<Text>();
        UpdateDisplay();
	}

    public void RemoveDrawCount() {
        drawCount -= 1;
        UpdateDisplay();
    }

    public void AddDrawCount() {
        drawCount += 1;
        UpdateDisplay();
    }

    public void UpdateDisplay() {
        drawCountText.text = drawCount + "x";
    }

    public void Clear() {
        drawCount = 3;
        UpdateDisplay();
    }
	
}
