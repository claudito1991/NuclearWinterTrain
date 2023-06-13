using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineDetection : MonoBehaviour
{
    WagonClassifier wagonClassifier;

    public Action<bool> TrainInStation;
    [SerializeField] bool isTrainInStation = false;


    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<WagonClassifier>().isEngine)
        {
            isTrainInStation = true;
            //FireStationTrigger(isTrainInStation);
            TrainInStation?.Invoke(isTrainInStation);
            Debug.Log("Triggered enter station");
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<WagonClassifier>().isEngine)
        {
            isTrainInStation = false;
            //FireStationTrigger(isTrainInStation);
            TrainInStation?.Invoke(isTrainInStation);
            Debug.Log("Triggered exit station");
            
        }
    }

    private void FireStationTrigger(bool stationState)
    {
        TrainInStation?.Invoke(stationState);
    }
    // Start is called before the first frame update

}
