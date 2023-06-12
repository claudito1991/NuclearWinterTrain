using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EngineDetection : MonoBehaviour
{
    WagonClassifier wagonClassifier;

    public Action<bool> TrainInStation;
    bool isTrainInStation = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<WagonClassifier>().isEngine)
        {
            isTrainInStation = !isTrainInStation;
            FireStationTrigger(isTrainInStation);
            Debug.Log("Triggered station");
            
        }
    }

    private void FireStationTrigger(bool stationState)
    {
        TrainInStation?.Invoke(stationState);
    }
    // Start is called before the first frame update

}
