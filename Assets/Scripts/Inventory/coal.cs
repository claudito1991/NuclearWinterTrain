using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coal : MonoBehaviour
{

    [SerializeField] int maxCoalAmount;
    [SerializeField] int minCoalAmount;
    [SerializeField] int coalAmount;

   // public static Action <int> AddCoalToInventory;

    void Start()
    {
        coalAmount = GenerateCoalAmount(maxCoalAmount, minCoalAmount);
    }

    public int  GenerateCoalAmount(int minVal, int maxVal)
    {
        coalAmount = UnityEngine.Random.Range(minVal, maxVal);
        return coalAmount;
    }

    public int GetCoalAmount()
    {
        return coalAmount;
    }

    public void CoalInteraction()
    {
        //AddCoalToInventory?.Invoke(coalAmount);
    }

    void OnMouseDown()
    {
        //CoalInteraction();
        Destroy(gameObject);
    }

}
