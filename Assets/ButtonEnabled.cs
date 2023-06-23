using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonEnabled : MonoBehaviour
{  
    Button thisButton;


    void Start()
    {
        thisButton = GetComponent<Button>();
    }
    void OnEnable()
    {   
        
    }
}
