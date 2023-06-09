using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WagonClassifier: MonoBehaviour 
{
    public int order; 
    public float speed; 
    public bool isEngine;
    public WagonClassifier(int order, float speed, bool isEngine)
    {
        this.order = order;
        this.speed = speed;
        this.isEngine = isEngine;
    }
}

