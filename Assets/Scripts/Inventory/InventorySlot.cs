using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public static Action <int> AddCoalToInventory;
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
        }

        if(transform.GetComponent<InventoryBoiler>())
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            int coal = dropped.GetComponent<DraggableItem>().count;
            draggableItem.parentAfterDrag = transform;
            AddCoalToInventory?.Invoke(coal);
            Destroy(dropped);
            Debug.Log("IN BOILER " + coal.ToString());

        }

        if(transform.GetComponent<StationInventory>())
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            int coal = dropped.GetComponent<DraggableItem>().count;
            draggableItem.parentAfterDrag = transform;
            //AddCoalToInventory?.Invoke(coal);
            Debug.Log("IN STATION " + coal.ToString());

        }

      

    }
}
