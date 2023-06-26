using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class DisplayCard : MonoBehaviour
{
    public List<Card> displayCard = new List<Card>();
    public int displayId;
    public Sprite spriteImage;

    public int id;

    public Image artImage;

    public bool cardBack;
    public static bool staticCardBack;

    public GameObject hand;
    public int numberOfCardsInDeck;

    // Start is called before the first frame update
    void Start()
    {
        numberOfCardsInDeck = PlayerDeck.deckSize;


        displayCard[0] = CardDatabase.cardList[displayId];

        


    }

    // Update is called once per frame
    void Update()
    {
        id = displayCard[0].id;

        spriteImage = displayCard[0].spriteImage;

        artImage.sprite = spriteImage;


        hand = GameObject.Find("Hand");
        if (this.transform.parent == hand.transform.parent)
        {
            cardBack = false;
        }
        staticCardBack = cardBack;

        if (this.tag == "Clone")
        {
            if (numberOfCardsInDeck != 0)
            {
                displayCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
                numberOfCardsInDeck -= 1;
                PlayerDeck.deckSize -= 1;
                cardBack = false;
                this.tag = "Untagged";
            }
        }

    }
}
