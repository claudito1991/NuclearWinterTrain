using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class WagonBehaviour : MonoBehaviour
{
    WagonClassifier wagonClass;
    SplineFollower splineFollower;
    // Start is called before the first frame update
    void Start()
    {
        wagonClass = GetComponent<WagonClassifier>();
        splineFollower = GetComponent<SplineFollower>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
