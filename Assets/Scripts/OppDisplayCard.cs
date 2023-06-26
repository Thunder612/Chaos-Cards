using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class OppDisplayCard : MonoBehaviour
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
    public int startingNumberofCards;

    // Start is called before the first frame update
    void Start()
    {
        numberOfCardsInDeck = OppDeck.oppDeckSize;
        startingNumberofCards = numberOfCardsInDeck;


        displayCard[0] = CardDatabase.cardList[displayId];

        if (numberOfCardsInDeck >= startingNumberofCards - 3)
        {
            cardBack = true;
        }




    }

    // Update is called once per frame
    void Update()
    {
        id = displayCard[0].id;

        spriteImage = displayCard[0].spriteImage;

        artImage.sprite = spriteImage;


        /*hand = GameObject.Find("OppZone");
        if (this.transform.parent == hand.transform.parent)
        {
            cardBack = false;
        }*/
        staticCardBack = cardBack;
        if (numberOfCardsInDeck != 0)
        {
            if (this.tag == "Clone")
            {
                displayCard[0] = OppDeck.oppStaticDeck[numberOfCardsInDeck - 1];
                numberOfCardsInDeck -= 1;
                OppDeck.oppDeckSize -= 1;
                //cardBack = false;
                this.tag = "Untagged";
            }
        }



    }
}
