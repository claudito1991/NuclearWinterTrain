using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class TrainSpeedController : MonoBehaviour
{
    [SerializeField] float trainSpeed;
    [SerializeField] float coalConsumptionRate;

    [SerializeField] float coalConsumptionMod;
    [SerializeField] float coalStock;

    [SerializeField] float accelerationRate;
    [SerializeField] int targetEnginePower;

    [SerializeField] WagonClassifier wagonClassifier;

    Inventory inventory;
    [SerializeField] float lerpDuration;

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        //ConsumeCoal(coalStock);
        CheckSpeedLimit();
        if(inventory.totalCoal >= 0)
        {
            if(Input.GetKeyUp(KeyCode.W))
            {
                StartCoroutine(FuelToEngine(coalConsumptionMod));
                CoalCosumption();
            }

            else if(Input.GetKeyUp(KeyCode.S))
            {

                StartCoroutine(ReleaseSteamFromEngine(coalConsumptionMod));
            }


        }
        else
        {
            StartCoroutine(StopEngine());
        }

    }

    private void ConsumeCoal(float coalStock)
    {
        //inventory.totalCoal = ((int)coalStock);
    }

    private void CheckSpeedLimit()
    {
        if(wagonClassifier.speed < 0f)
        {
            wagonClassifier.speed = 0f;
        }

        else if(wagonClassifier.speed > 10f)
        {
            wagonClassifier.speed = 10f;
        }
    }

    private void StopTrain()
    {
        float lastSpeed = 
        wagonClassifier.speed = Mathf.Lerp(wagonClassifier.speed, 0f, Time.deltaTime * 10f);
    }

    private void CoalCosumption()
    {
        //inventory.totalCoal  -= ((int)(coalConsumptionRate * Time.deltaTime));
        inventory.ConsumeCoal(coalConsumptionRate * Time.deltaTime);
        if (Mathf.Abs(inventory.totalCoal) < 0.3f)
        {
            inventory.totalCoal = 0;
        }
    }

    // private void FuelToEngine()
    // {
    //     coalConsumptionRate += 0.1f;
    //     trainSpeed = Mathf.Lerp(trainSpeed, trainSpeed * (1+coalConsumptionRate), Time.deltaTime);
    //     wagonClassifier.speed = trainSpeed;
    // }

    IEnumerator FuelToEngine(float coalConsumption)
    {
        float timeElapsed=0f;
        coalConsumptionRate += coalConsumption;
        float target = trainSpeed + coalConsumptionRate * accelerationRate;

        Debug.Log("Target acceleration" + target);

        while(timeElapsed<lerpDuration)
        {

            wagonClassifier.speed = Mathf.Lerp(trainSpeed, target, timeElapsed/lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        wagonClassifier.speed = target;
    }

    IEnumerator ReleaseSteamFromEngine(float coalConsumption)
    {
        float timeElapsed=0f;
        coalConsumptionRate -= coalConsumption;
        float target = trainSpeed - (coalConsumptionRate * accelerationRate);

        Debug.Log("Target Slowing down" + target);

        while(timeElapsed<lerpDuration)
        {
            wagonClassifier.speed = Mathf.Lerp(trainSpeed, target, timeElapsed/lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        wagonClassifier.speed = target;
    }

        IEnumerator StopEngine()
    {
        float timeElapsed=0f;
        float target = 0f;

        while(timeElapsed<lerpDuration)
        {
            wagonClassifier.speed = Mathf.Lerp(wagonClassifier.speed, target, timeElapsed/lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        wagonClassifier.speed = target;
    }

}
