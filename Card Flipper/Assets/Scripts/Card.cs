using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    private Image image;
    private bool hovering = false;
    private bool selected = false;

    private void Start() {
        image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        hovering = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        hovering = false;
    }

    public void OnPointerClick(PointerEventData eventData) {
        FlipCard();
    }

    private void HighLightCard() {
        if (hovering) {
            image.color = Color.red;
        }
        else {
            image.color = Color.white;
        }
    }

    private void FlipCard() {
        image.color = Color.blue;
        selected = true;
    }
    
    private void Update () {
        if (selected)
            return;

        HighLightCard();
	}
}
