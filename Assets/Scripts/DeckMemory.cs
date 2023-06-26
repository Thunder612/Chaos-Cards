using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckMemory : MonoBehaviour
{

    public static DeckMemory instance;
    public List<Card> memoryDeck = new List<Card>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void Commit(List<Card> deck)
    {
        memoryDeck.Clear();
        foreach (Card card in deck)
        {
            memoryDeck.Add(card);
        }
    }

    public List<Card> getMemoryDeck()
    {
        return memoryDeck;
    }
}
