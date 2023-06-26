using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerZone : MonoBehaviour, IDropHandler
{
    public List<DisplayCard> playedCards = new List<DisplayCard>();
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<Drag>().GetParentToReturnTo() != this.transform)
        {
            if (playedCards.Count < 5)
            {
                eventData.pointerDrag.GetComponent<Drag>().SetParentToReturnTo(this.transform);
                playedCards.Add(eventData.pointerDrag.gameObject.GetComponent<DisplayCard>());
            }
        }
    }

    public List<DisplayCard> GetPlayedCards()
    {
        return playedCards;
    }
}
