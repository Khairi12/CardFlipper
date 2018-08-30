using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Lists the type of cards the player can draw
public enum CardType { Common, Uncommon, Rare, Epic, Legendary };

// Card Class: inherits MonoBehavior, implements IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
// MonoBehaviour - allows the class to be used as a unity component, letting this script attach itself to a game object
// Ipointerenter / IPointerexit / Ipointerclick - interfaces using common mouse actions
public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {
    public CardType cardType;

    private CardManager cm;             // manages the cards created for the program 
    private DrawManager dm;             // manages the allotted draws for the player
    private RewardManager rm;           // manages the possible rewards to obtain
    private InventoryManager im;        // manages the cards the player drew

    private bool opened = false;        // prevent opening again if the card is already opened
    
    // Unity Scripts / Components
    private Image backImage;            // Reference to the image component of the background that will be used to create highlights
    private Color defaultBackColor;     // Default color of the background color

    // Built-in Unity method called whenever the game starts
    private void Start() {
        cm = CardManager.cm;
        dm = DrawManager.dm;
        rm = RewardManager.rm;
        im = InventoryManager.im;

        // Finds and References the Image component on the gameobject this script is attached to
        backImage = GetComponent<Image>();

        defaultBackColor = backImage.color;
    }

    // Method called when mouse enters the gameobject this script is attached to
    public void OnPointerEnter(PointerEventData eventData) {
        if (dm.drawCount == 0 || opened)
            return;

        backImage.color = Color.white;
    }

    // Method called whenever the mouse leaves
    public void OnPointerExit(PointerEventData eventData) {
        if (dm.drawCount == 0 || opened)
            return;

        backImage.color = defaultBackColor;
    }
    
    // Method called whenever the mouse clicks
    public void OnPointerClick(PointerEventData eventData) {
        if (dm.drawCount > 0 && !opened)
        {
            opened = true;

            // Destroys the specified gameobject (in this case, the gameobject on top of the card to reveal what's under it)
            Destroy(transform.GetChild(1).gameObject);

            // creates a separate process (thread?) for the specified method
            StartCoroutine(PlayCardAnimation());

            // let the RoomManager know that a card was removed
            rm.RemoveCard(cardType);

            // let the DrawManager know that a draw count was used
            dm.RemoveDrawCount();

            // let InventoryManager know that a card was added
            im.AddCard(cardType);
        }
    }

    // Card animation played when the player draws a card. Maximize opacity, then gradually set to default opacity
    private IEnumerator PlayCardAnimation() {

        // set the background image opacity to 100%
        backImage.color = new Color(
            backImage.color.r,
            backImage.color.g,
            backImage.color.b,
            1f);

        // decrement the background image opacity
        while (backImage.color.a > defaultBackColor.a) {

            // set the background image opacity to itself, minus 10%
            backImage.color = new Color(
                backImage.color.r,
                backImage.color.g,
                backImage.color.b,
                backImage.color.a - 0.1f);

            // pause the process for the amount of time it took to complete the last frame
            yield return new WaitForSeconds(Time.deltaTime);
        }
        
        yield return null;
    }
}
