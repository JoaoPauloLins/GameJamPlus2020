using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class OrganizeItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform itemRectTransform;
    [SerializeField] private float minimalDistance;

    private RectTransform boxRectTransform;

    private Action OnCorrectItemPosition;

    private bool isMovable;

    private void Start() {
        this.isMovable = true;
    }

    public void init(RectTransform boxRectTransform, Action OnCorrectItemPositionHandler) {
        this.boxRectTransform = boxRectTransform;
        this.OnCorrectItemPosition = OnCorrectItemPositionHandler;
    }

    public void setPosition(Vector2 newPos) {
        this.itemRectTransform.anchoredPosition = newPos;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (this.isMovable) {
            this.itemRectTransform.SetAsLastSibling();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isMovable) {
            Vector2 currentPos = this.itemRectTransform.position;
            float newPosX = currentPos.x + eventData.delta.x;
            float newPosY = currentPos.y + eventData.delta.y;
            this.itemRectTransform.position = new Vector2(newPosX, newPosY);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isMovable) {
            Vector2 itemFinalPos = this.itemRectTransform.position;
            Vector2 boxPos = this.boxRectTransform.position;
            float distance = Vector2.Distance(itemFinalPos, boxPos);
            if (distance <= minimalDistance) {
                OnCorrectItemPosition?.Invoke();
                this.isMovable = false;
            }
        }
    }
}
