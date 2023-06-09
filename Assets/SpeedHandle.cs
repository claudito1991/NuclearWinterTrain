using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SpeedHandle : MonoBehaviour
{
    public Action<int> HandleMoved;
    [SerializeField] Slider slider;
    public int speedValue;
    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener((v)=>
        {
            speedValue = ((int)v);
            HandleMoved?.Invoke(speedValue);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
