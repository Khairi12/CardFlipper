using UnityEngine;
using UnityEngine.UI;

public class DrawManager : MonoBehaviour {
    public static DrawManager dm;
    public int drawCount;
    
    private Text drawCountText;

    // Built-in Unity method called when the game first initializes, called before Start()
    private void Awake() {
        dm = this;
    }

    // Built-in Unity method called whenever the game starts
    private void Start () {
        drawCount = 3;

        // creates reference to the text component attached to the child of this game object
        drawCountText = transform.GetChild(1).GetComponent<Text>();

        Refresh();
	}

    public void RemoveDrawCount() {
        drawCount -= 1;

        Refresh();
    }

    public void AddDrawCount() {
        drawCount += 1;

        Refresh();
    }

    public void Refresh() {
        drawCountText.text = drawCount + "x";
    }

    public void Clear() {
        drawCount = 3;

        Refresh();
    }
	
}
