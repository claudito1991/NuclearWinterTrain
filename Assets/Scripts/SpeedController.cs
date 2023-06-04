using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class SpeedController : MonoBehaviour
{
    SplineFollower splineFollower;
    WagonClassifier wagonClassifier;
    List<WagonClassifier> wagonClassifiers;

    float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        splineFollower = GetComponent<SplineFollower>();
        wagonClassifier = GetComponent<WagonClassifier>();
        wagonClassifiers = GetComponentsInChildren<WagonClassifier>().ToList();
    }
    // Update is called once per frame
    void Update()
    {
        if(wagonClassifier.isEngine)
        {
            splineFollower.followSpeed = Mathf.Lerp(splineFollower.followSpeed, wagonClassifier.speed, Time.deltaTime * 1f) ;
            currentSpeed = splineFollower.followSpeed;
        }

        else
        {
            splineFollower.followSpeed = wagonClassifier.speed;
        }

        foreach(WagonClassifier wagon in wagonClassifiers)
        {
            wagon.speed = currentSpeed;
        }
    }



    
}
