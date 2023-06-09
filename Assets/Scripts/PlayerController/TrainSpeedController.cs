using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class TrainSpeedController : MonoBehaviour
{
    [SerializeField] float trainSpeed;
    [SerializeField] int newTrainSpeed;
    [SerializeField] float coalConsumptionRate;

    [SerializeField] float coalConsumptionMod;

    [SerializeField] float accelerationRate;
    [SerializeField] int targetEnginePower;

    [SerializeField] WagonClassifier wagonClassifier;
    [SerializeField] SpeedHandle speedHandle;

    Inventory inventory;
    [SerializeField] float reactionDelay;

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
        if(inventory.totalCoal > 0)
        {
            if(Input.GetKeyUp(KeyCode.W))
            {

                //StartCoroutine(FuelToEngine(coalConsumptionMod));
            }

            else if(Input.GetKeyUp(KeyCode.S))
            {

                //StartCoroutine(ReleaseSteamFromEngine(coalConsumptionMod));
            }

            CoalCosumption();


        }

        
        else
        {
            StartCoroutine(StopEngine());
        }

    }

    void OnEnable()
    {
        speedHandle.HandleMoved += SpeedChanged;
    }

    public void SpeedChanged(int value)
    {
        switch (value)
        {
        case 4:
            print ("SPEED 15");
            StartCoroutine(FuelToEngine(5.0f));
            break;
        case 3:
            print ("SPEED 12");
            StartCoroutine(FuelToEngine(3.0f));
            break;
        case 2:
            print ("SPEED 8");
            StartCoroutine(FuelToEngine(2.0f));
            break;
        case 1:
            print ("SPEED 3");
            StartCoroutine(FuelToEngine(1.0f));
            break;
        default:
            print ("Roto");
            StartCoroutine(FuelToEngine(0.0f));
            break;
        }
    }

    void OnDisable()
    {
        speedHandle.HandleMoved -= SpeedChanged;
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


    private void CoalCosumption()
    {
        //inventory.totalCoal  -= ((int)(coalConsumptionRate * Time.deltaTime));
        inventory.ConsumeCoal(coalConsumptionRate * Time.deltaTime);
        if (Mathf.Abs(inventory.totalCoal) < 0.3f)
        {
            inventory.totalCoal = 0;
            coalConsumptionRate = 0;
        }
    }

    IEnumerator FuelToEngine(float coalConsumption)
    {
        float timeElapsed=0f;
        coalConsumptionRate += coalConsumption;
        float target = trainSpeed + coalConsumptionRate * accelerationRate;

        

        while(timeElapsed<reactionDelay)
        {

            wagonClassifier.speed = Mathf.Lerp(trainSpeed, target, timeElapsed/reactionDelay);
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


        while(timeElapsed<reactionDelay)
        {
            wagonClassifier.speed = Mathf.Lerp(trainSpeed, target, timeElapsed/reactionDelay);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        wagonClassifier.speed = target;
    }

        IEnumerator StopEngine()
    {
        float timeElapsed=0f;
        float target = 0f;

        while(timeElapsed<reactionDelay)
        {
            wagonClassifier.speed = Mathf.Lerp(wagonClassifier.speed, target, timeElapsed/reactionDelay);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        wagonClassifier.speed = target;
    }

}
