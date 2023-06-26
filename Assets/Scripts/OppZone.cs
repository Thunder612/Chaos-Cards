using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppZone : MonoBehaviour
{


    public List<OppDisplayCard> playedCards = new List<OppDisplayCard>();

    public List<OppDisplayCard> GetPlayedCards()
    {
        return playedCards;
    }

    public void drawCard(OppCardToHand card)
    {
        playedCards.Add(card.GetComponent<OppDisplayCard>());
    }

}
