using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour
{
    [SerializeField] EngineDetection engineDetection;
    [SerializeField] List<WagonClassifier> wagonClassifiers;
    void Start()
    {
        //engineDetection = GetComponentInChildren<EngineDetection>();
        wagonClassifiers = FindObjectsOfType<WagonClassifier>().ToList();
    }


    void OnEnable()
    {
        engineDetection.TrainInStation += SlowDownTrain;
    }

    private void SlowDownTrain()
    {
        Debug.Log("Slow down train");
        foreach(WagonClassifier wagon in wagonClassifiers)
        {
           wagon.speed = 0;
        }
    }

    // Start is called before the first frame update



    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        engineDetection.TrainInStation -= SlowDownTrain;
    }


}
