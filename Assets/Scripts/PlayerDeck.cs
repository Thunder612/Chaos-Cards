using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public Card container;
    public int x;
    public static int deckSize = 20;
    public List<Card> deck = new List<Card>();
    public static List<Card> staticDeck = new List<Card>();
    public List<Card> loadedDeck = new List<Card>();

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;
    public GameObject cardInDeck5;
    public GameObject cardInDeck6;

    public GameObject cardToHand;
    public GameObject[] Clones;
    public GameObject hand;

    public GameObject deckMemory;



    // Start is called before the first frame update
    void Start()
    {
        foreach (Card card in DeckMemory.instance.memoryDeck)
        {
            loadedDeck.Add(card);
        }
        if (loadedDeck.Count < 3)
        {
            x = 0;
            deckSize = 20;
            for (int i = 0; i < deckSize; i++)
            {
                x = Random.Range(1, 52);
                deck[i] = CardDatabase.cardList[x];
            }
        } else
        {
            int realCards = 0;
            foreach (Card card in loadedDeck)
            {
                if (card.value > 0)
                {
                    realCards++;
                }
            }
            deckSize = realCards;

            for (int i = 0; i < loadedDeck.Count; i++)
            {
                deck[i] = loadedDeck[i];
            }
        }
        Shuffle();

        DeckMemory.instance.Commit(deck);

        StartCoroutine(StartGame());

    }

    // Update is called once per frame
    void Update()
    {

        staticDeck = deck;



        if (deckSize < 50)
        {
            cardInDeck1.SetActive(false);
        } else
        {
            cardInDeck1.SetActive(true);
        }

        if (deckSize < 40)
        {
            cardInDeck2.SetActive(false);
        }
        else
        {
            cardInDeck2.SetActive(true);
        }

        if (deckSize < 30)
        {
            cardInDeck3.SetActive(false);
        }
        else
        {
            cardInDeck3.SetActive(true);
        }

        if (deckSize < 20)
        {
            cardInDeck4.SetActive(false);
        }
        else
        {
            cardInDeck4.SetActive(true);
        }

        if (deckSize < 10)
        {
            cardInDeck5.SetActive(false);
        }
        else
        {
            cardInDeck5.SetActive(true);
        }

        if (deckSize < 1)
        {
            cardInDeck6.SetActive(false);
        }
        else
        {
            cardInDeck6.SetActive(true);
        }



        if (TurnSystem.startTurn)
        {
            if (deckSize > 0)
            {
                StartCoroutine(Draw(1));
            }
            TurnSystem.startTurn = false;
        }

    }

    IEnumerator StartGame()
    {
        for (int i = 1; i <= 3; i++)
        {
            yield return new WaitForSeconds(1);

            Instantiate(cardToHand, transform.position, transform.rotation);
        }
    }


    public void Shuffle()
    {
        for (int i = 0; i < deckSize; i++)
        {
            container = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container; //Why is container a list if we only ever use [0]?
        }


        AudioManager.instance.ShuffleSFX();
    }

    IEnumerator Draw(int x)
    {
        for(int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(.75f);
            Instantiate(cardToHand, transform.position, transform.rotation);
        }

        AudioManager.instance.DrawSFX();
    }
}
