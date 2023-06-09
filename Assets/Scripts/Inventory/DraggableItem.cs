using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    

    [Header("UI")]
    public Image image;
    public Text countText;

    [HideInInspector] public Item item;
    [HideInInspector] public int count = 1;

    
    [HideInInspector] public Transform parentAfterDrag;

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        RefreshCount();
    }



    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count>1;
        countText.gameObject.SetActive(textActive);
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.parent.parent);
        transform.parent.SetAsLastSibling();
        image.raycastTarget = false;
    }



    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

}
