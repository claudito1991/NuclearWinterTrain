using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressureLevel : MonoBehaviour
{   

    [SerializeField] PressureBar pressureBar;

    [SerializeField] private float totalPressure;
    [SerializeField] private float maxPressure;
    [SerializeField] private float energyConversionModifier;
    [SerializeField] private float pressureLossRate;


    void Update()
    {
        LosingPressureOverTime();
        pressureBar.SetPressure(totalPressure);
    }
    void OnEnable()
    {
        pressureBar.SetMaxPressure(maxPressure);
    }
    
    public void AddPressure(float coalAdded)
    {
        totalPressure += coalAdded * energyConversionModifier;
    }

        private void LosingPressureOverTime()
    {
        totalPressure -= Time.deltaTime * pressureLossRate;
    
    }


}


