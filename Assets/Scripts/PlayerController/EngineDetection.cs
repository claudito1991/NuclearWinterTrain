using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EngineDetection : MonoBehaviour
{
    WagonClassifier wagonClassifier;

    public Action TrainInStation;
    bool isTrainInStation;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<WagonClassifier>().isEngine)
        {
            FireStationTrigger();
        }

        else
        {
            Debug.Log("nada");
        }
    }

    private void FireStationTrigger()
    {
        TrainInStation?.Invoke();
    }
    // Start is called before the first frame update

}
