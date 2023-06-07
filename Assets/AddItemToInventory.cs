using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemToInventory : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item itemToPickUp;
    // Start is called before the first frame update
    
    void OnMouseDown()
    {
        inventoryManager.AddItem(itemToPickUp);
    }
}
