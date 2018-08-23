using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum CardType { Common, Uncommon, Rare, Epic, Legendary };

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {
    
    public CardType cardType;

    private Image image;
    private Color defaultColor;
    private bool hovering = false;
    private bool selected = false;

    private void Start() {
        image = GetComponent<Image>();
        defaultColor = image.color;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        hovering = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        hovering = false;
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (selected)
            return;

        image.color = Color.white;
        FlipCard();
    }

    private void HighLightCard() {
        if (hovering) {
            image.color = Color.white;
        }
        else {
            image.color = defaultColor;
        }
    }

    private IEnumerator PlayCardAnimation() {
        image.color = new Color(
            image.color.r,
            image.color.g,
            image.color.b,
            1f);

        while (image.color.a > defaultColor.a)
        {
            image.color = new Color(
                image.color.r,
                image.color.g,
                image.color.b,
                image.color.a - 0.1f);

            yield return new WaitForSeconds(Time.deltaTime);
        }

        yield return null;
    }

    private void FlipCard() {
        if (CardManager.cardDraws > 0) {
            selected = true;
            Destroy(transform.GetChild(1).gameObject);
            StartCoroutine(PlayCardAnimation());
        }
        else {

        }

    }
    
    private void Update () {
        if (selected)
            return;

        HighLightCard();
	}
}
