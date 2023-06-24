using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationController : MonoBehaviour
{
    [SerializeField] EngineDetection engineDetection;
    [SerializeField] List<WagonClassifier> wagonClassifiers;

    [SerializeField] Image stationImageUI;

    private SendRosourcesToStation sendRosourcesToStation;

    [SerializeField] GameObject sendResButtonUI;

    [SerializeField] GameObject stationInventory;

    private bool stationInvIsActive;

    public bool StationInvIsActive{get{return stationInvIsActive;}}



    void Start()
    {
        //engineDetection = GetComponentInChildren<EngineDetection>();
        wagonClassifiers = FindObjectsOfType<WagonClassifier>().ToList();
        sendRosourcesToStation = GetComponent<SendRosourcesToStation>();
    }


    void OnEnable()
    {
        engineDetection.TrainInStation += ShowStationInventory;
    }

    private void SlowDownTrain()
    {
        //Debug.Log("Slow down train");
        foreach(WagonClassifier wagon in wagonClassifiers)
        {
            wagon.Speed = 0;
        }
    }

    private void ShowStationInventory(bool stationInvState)
    {
        //Debug.Log("Trigger bool " + stationInvState.ToString());
        stationInventory.SetActive(stationInvState);
        sendResButtonUI.SetActive(stationInvState);
        sendRosourcesToStation.AssignThisButton();
        stationImageUI.enabled = stationInvState;
        stationInvIsActive = stationInvState;  
    }


    void OnDisable()
    {
        engineDetection.TrainInStation -= ShowStationInventory;
    }


}
