using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WagonClassifier: MonoBehaviour 
{
    public int order; 
    [SerializeField] private float speed;
    public float Speed {
        get => speed; 
        set {speed=Mathf.Clamp(value,0,15);
        Debug.Log("Speed changed in setter" + speed.ToString());}
        }
    public bool isEngine;


    public WagonClassifier(int order, float speed, bool isEngine)
    {
        this.order = order;
        this.speed = speed;
        this.isEngine = isEngine;
    }
}

