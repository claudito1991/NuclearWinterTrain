using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressureLevel : MonoBehaviour
{   

    [SerializeField] PressureBar pressureBar;

    [SerializeField] private float totalPressure;
    public float CurrentPressure{get{ return totalPressure;}}
    [SerializeField] private float maxPressure;
    public float MaxPressure{get{ return maxPressure;}}
    [SerializeField] private float energyConversionModifier;
    [SerializeField] private float pressureLossRate;


    void Update()
    {
        if(totalPressure>maxPressure)
        {
            totalPressure = maxPressure;
        }
        //SetPressureInInv(); 
    }

    void Start()
    {
        pressureBar.SetMaxPressure(maxPressure);
    }

    public void SetPressureInInv(int pressureToSet)
    {
        pressureBar.SetPressure(pressureToSet);
    }

    void OnEnable()
    {
        //pressureBar.SetMaxPressure(maxPressure);
    }
    
    public void AddPressure(float coalAdded)
    {
        if(totalPressure> maxPressure)
        {
            totalPressure = maxPressure;
        }
        else
        {
            totalPressure += coalAdded;
        }

    }

        private void LosingPressureOverTime()
    {
        totalPressure -= Time.deltaTime * pressureLossRate;
    }


}


