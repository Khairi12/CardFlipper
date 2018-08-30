using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

    // public static reference of itself so that other scripts in different gameobjects will have access
    // to this gameobjects information
    public static CardManager cm;

    // the amount of cards to be created
    public int cardAmount;

    // A list of GameObject type that will be loaded in the game
    // GameObject - represents the game object (currently null) in the game
    public List<GameObject> cards = new List<GameObject>();

    // private reference to the RewardManager gameobject
    private RewardManager rm;

    // private references to the card types (gameobjects) inside the Resource folder
    private GameObject commonCard;
    private GameObject uncommonCard;
    private GameObject rareCard;
    private GameObject epicCard;
    private GameObject legendaryCard;

    // Built-in Unity method called when the game first initializes, called before Start()
    private void Awake() {

        // assign cm to reference this specific class attached to the game object
        cm = this;
    }

    // Built-in Unity method called whenever the game starts
    private void Start() {

        // references the RoomManager gameobject outside of this gameobject
        rm = RewardManager.rm;
        
        // gets the specified GameObject from resources folder as a GameObject type
        commonCard = Resources.Load<GameObject>("CommonCard");
        uncommonCard = Resources.Load<GameObject>("UncommonCard");
        rareCard = Resources.Load<GameObject>("RareCard");
        epicCard = Resources.Load<GameObject>("EpicCard");
        legendaryCard = Resources.Load<GameObject>("LegendaryCard");

        CreateCards();
    }

    // Returns the game object that will be used in the program
    private GameObject SelectCardType() {
        // Unity Random.Range returns a random value from 0 - 100
        int value = Random.Range(0, 100);

        if (value < 1) {
            return legendaryCard;
        }
        else if (value < 5) {
            return epicCard;
        }
        else if (value < 30) {
            return rareCard;
        }
        else if (value < 50) {
            return uncommonCard;
        }
        else {
            return commonCard;
        }
    }

    // Generates and saves a list of cards that will be used
    public void CreateCards() {
        for (int i = 0; i < cardAmount; i++) {
            GameObject card = SelectCardType();
            cards.Add(card);

            // Instantiate - spawns the game object into the game
            Instantiate(card, transform);
        }
    }

    public void Clear() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }

        cards.Clear();
    }

}