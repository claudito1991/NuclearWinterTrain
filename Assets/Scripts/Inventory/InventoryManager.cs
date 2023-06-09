using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject InventoryItemPrefab;
    public int maxStackedItems = 10;

    public void AddItem(Item item, coal coal)
    {
        for (int i = 0; i<inventorySlots.Length; i++)
            {
                InventorySlot slot = inventorySlots[i];
                DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
        
                if(itemInSlot != null &&
                    itemInSlot.item == item &&
                    itemInSlot.count < maxStackedItems &&
                    itemInSlot.item.stackable == true)
                {
                    //itemInSlot.count++;
                    itemInSlot.count = coal.GetCoalAmount();
                    itemInSlot.RefreshCount();
                    return;
                }

            }
            for (int i = 0; i<inventorySlots.Length; i++)
            {
                InventorySlot slot = inventorySlots[i];
                DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
                if(itemInSlot == null)
                {
                    SpawnNewItem(item, slot);
                    DraggableItem itemNowInSlot = slot.GetComponentInChildren<DraggableItem>();
                    itemNowInSlot.count = coal.GetCoalAmount();
                    itemNowInSlot.RefreshCount();                    
                    return;
                }
            }
    }

    private void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(InventoryItemPrefab, slot.transform);
        DraggableItem inventoryItem = newItemGo.GetComponent<DraggableItem>();
        inventoryItem.InitialiseItem(item);
    }
}
