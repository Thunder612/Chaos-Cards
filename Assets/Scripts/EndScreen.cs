using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public GameObject deckMemory;
    public Text bundle1Text;

    Card card1;
    Card card2;
    Card card3;

    public void Start()
    {
        card1 = CardDatabase.cardList[Random.Range(1, 52)];
        card2 = CardDatabase.cardList[Random.Range(1, 52)];
        card3 = CardDatabase.cardList[Random.Range(1, 52)];

        bundle1Text.text = "Add " + card1.cardName + ", " + card2.cardName + ", and " + card3.cardName;
    }


    public void Reset()
    {

        DeckMemory.instance.Commit(new List<Card>());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void addNoCards()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void addBundle1()
    {
        int count = 3;
        

        for (int i = 0; i < DeckMemory.instance.memoryDeck.Count; i++)
        {
            if (DeckMemory.instance.memoryDeck[i].value < 1 && count == 3)
            {
                DeckMemory.instance.memoryDeck[i] = card3;
                count--;

            } else if (DeckMemory.instance.memoryDeck[i].value < 1 && count == 2)
            {
                DeckMemory.instance.memoryDeck[i] = card2;
                count--;

            } else if (DeckMemory.instance.memoryDeck[i].value < 1 && count == 1)
            {
                DeckMemory.instance.memoryDeck[i] = card1;
                count--;

            }
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
