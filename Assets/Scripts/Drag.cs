using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas;
    public Transform parentToReturnTo = null;
    private CanvasGroup canvasGroup;

    private void Awake()
    {

        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);
        canvasGroup.blocksRaycasts = true;
    }

    public void SetParentToReturnTo(Transform a)
    {
        parentToReturnTo = a;
    }

    public Transform GetParentToReturnTo()
    {
        return parentToReturnTo;
    }

    





    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
