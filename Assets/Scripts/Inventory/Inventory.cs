using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public float totalCoal;
    Inventory inventory;
    ShowCoalUI coalUI;
    // Start is called before the first frame update

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        coalUI = FindObjectOfType<ShowCoalUI>();
    }
    void OnEnable()
    {
        InventorySlot.AddCoalToInventory += AddCoal;
    }

    private void AddCoal(int obj)
    {
        totalCoal += obj;
        coalUI.UpdateCoalInUI(((int)totalCoal));
    }

    void OnDisable()
    {
        InventorySlot.AddCoalToInventory -= AddCoal;
    }

    public void ConsumeCoal(float coalConsumption)
    {
        totalCoal -= coalConsumption;
        Debug.Log(coalConsumption);
    }

}
