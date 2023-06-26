using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppDeck : MonoBehaviour
{
    public Card container;
    public int x;
    public static int oppDeckSize; //Deck size is currently not being intitialized
    public List<Card> deck = new List<Card>();
    public static List<Card> oppStaticDeck = new List<Card>();

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;
    public GameObject cardInDeck5;
    public GameObject cardInDeck6;

    public GameObject oppCardToHand;
    public GameObject[] Clones;
    public GameObject oppHand;

    public static int oppDesiredValue = 6;
    public static string oppDesiredHand = "Straight";



    // Start is called before the first frame update
    void Start()
    {
        
        oppDeckSize = 20;
        deck[0] = CardDatabase.cardList[2]; // 2 of Spades
        deck[1] = CardDatabase.cardList[16]; // 3 of Clubs
        deck[2] = CardDatabase.cardList[30]; //4 of Diamonds
        deck[3] = CardDatabase.cardList[44]; //5 of Hearts
        deck[4] = CardDatabase.cardList[6]; //6 of Spades
        for (int i = 5; i < oppDeckSize; i++)
        {
            x = Random.Range(1, 52);
            deck[i] = CardDatabase.cardList[x];
        }
        Shuffle();


        StartCoroutine(StartGame());

    }

    // Update is called once per frame
    void Update()
    {

        oppStaticDeck = deck;



        if (oppDeckSize < 50)
        {
            cardInDeck1.SetActive(false);
        }
        else
        {
            cardInDeck1.SetActive(true);
        }

        if (oppDeckSize < 40)
        {
            cardInDeck2.SetActive(false);
        }
        else
        {
            cardInDeck2.SetActive(true);
        }

        if (oppDeckSize < 30)
        {
            cardInDeck3.SetActive(false);
        }
        else
        {
            cardInDeck3.SetActive(true);
        }

        if (oppDeckSize < 20)
        {
            cardInDeck4.SetActive(false);
        }
        else
        {
            cardInDeck4.SetActive(true);
        }

        if (oppDeckSize < 10)
        {
            cardInDeck5.SetActive(false);
        }
        else
        {
            cardInDeck5.SetActive(true);
        }

        if (oppDeckSize < 1)
        {
            cardInDeck6.SetActive(false);
        }
        else
        {
            cardInDeck6.SetActive(true);
        }



        if (TurnSystem.startTurn)
        {
            if (oppDeckSize > 0)
            {
                StartCoroutine(Draw(1));
            }
            TurnSystem.oppStartTurn = false;
        }

    }

    IEnumerator StartGame()
    {
        for (int i = 1; i <= 3; i++)
        {
            yield return new WaitForSeconds(1);

            Instantiate(oppCardToHand, transform.position, transform.rotation);
        }
    }


    public void Shuffle()
    {
        for (int i = 0; i < oppDeckSize; i++)
        {
            container = deck[i];
            int randomIndex = Random.Range(i, oppDeckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container; //Why is container a list if we only ever use [0]?
        }


        AudioManager.instance.ShuffleSFX();
    }

    IEnumerator Draw(int x)
    {
        for (int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(.75f);
            Instantiate(oppCardToHand, transform.position, transform.rotation);


            AudioManager.instance.DrawSFX();
        }
    }
}
