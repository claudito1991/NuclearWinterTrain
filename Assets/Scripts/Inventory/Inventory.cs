using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    ShowCoalUI coalUI;
    [SerializeField] PressureBar pressureBar;
    PressureLevel pressureLevel;
    public float totalCoal;
    public float totalPressure;
    public float pressureLossRate;
    public int maxPressure;
    public int energyConversionModifier = 1;
    //Inventory inventory;




    // Start is called before the first frame update

    void Start()
    {
        //inventory = FindObjectOfType<Inventory>();
        coalUI = FindObjectOfType<ShowCoalUI>();
        pressureLevel = FindObjectOfType<PressureLevel>();

        coalUI.UpdateCoalInUI(((int)totalCoal));
    }

    void Update()
    {
        //LosingPressureOverTime();
        //pressureBar.SetPressure(totalPressure);
    }
    void OnEnable()
    {
        //pressureBar.SetMaxPressure(maxPressure);
        InventorySlot.AddCoalToInventory += AddCoal;
    }

    private void AddCoal(int obj)
    {
        if(totalCoal<pressureLevel.MaxPressure)
        {
            totalCoal += obj * energyConversionModifier;
            pressureLevel.AddPressure(obj* energyConversionModifier);
        }
        else
        {
            totalCoal = maxPressure;
        }
        if(totalCoal>pressureLevel.MaxPressure)
        {
            totalCoal = maxPressure;
        }
  
        
        coalUI.UpdateCoalInUI(((int)totalCoal));
    }

    private void LosingPressureOverTime()
    {
        totalPressure -= Time.deltaTime * pressureLossRate;
    }

    private void AddPressure(float coalAdded)
    {
        totalPressure += coalAdded * energyConversionModifier;
    }

    void OnDisable()
    {
        InventorySlot.AddCoalToInventory -= AddCoal;
    }

    public void ConsumeCoal(float coalConsumption)
    {
        totalCoal -= coalConsumption;
        coalUI.UpdateCoalInUI(((int)totalCoal));
    }

}
