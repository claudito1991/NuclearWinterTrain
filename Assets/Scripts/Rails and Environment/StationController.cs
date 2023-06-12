using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour
{
    [SerializeField] EngineDetection engineDetection;
    [SerializeField] List<WagonClassifier> wagonClassifiers;

    [SerializeField] GameObject stationInventory;
    void Start()
    {
        //engineDetection = GetComponentInChildren<EngineDetection>();
        wagonClassifiers = FindObjectsOfType<WagonClassifier>().ToList();
    }


    void OnEnable()
    {
        engineDetection.TrainInStation += ShowStationInventory;
    }

    private void SlowDownTrain()
    {
        Debug.Log("Slow down train");
        foreach(WagonClassifier wagon in wagonClassifiers)
        {
           wagon.Speed = 0;
        }
    }

    private void ShowStationInventory(bool stationInvState)
    {
        Debug.Log("Trigger bool " + stationInvState.ToString());
        stationInventory.SetActive(stationInvState);
    }

    // Start is called before the first frame update



    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        engineDetection.TrainInStation -= ShowStationInventory;
    }


}
