using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int totalCoal;
    Inventory inventory;
    // Start is called before the first frame update

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }
    void OnEnable()
    {
        coal.AddCoalToInventory += AddCoalToInventory;
    }

    private void AddCoalToInventory(int obj)
    {
        totalCoal += obj;
    }

    void OnDisable()
    {
        coal.AddCoalToInventory -= AddCoalToInventory;
    }

    public void ConsumeCoal(float coalConsumption)
    {
        if(coalConsumption>0)
        {
            totalCoal += (int)coalConsumption;
            Debug.Log(coalConsumption);
        }
        else
        {
            totalCoal -= (int)coalConsumption;
            Debug.Log(coalConsumption);
        }
        
    }
}
