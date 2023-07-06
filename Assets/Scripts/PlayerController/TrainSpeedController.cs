using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class TrainSpeedController : MonoBehaviour
{
    [SerializeField] float trainSpeed;
    [SerializeField] AudioSource trainAudioSource;
    [SerializeField] ContainMusic musicContainer;
    [SerializeField] AudioSource engineAudioSource;
    [SerializeField] BreakTrainOverTime breakTrainOverTime;
    
    public float TrainSpeed {
        get{return trainSpeed;}
        }
    [SerializeField] int newTrainSpeed;
    private float coalConsumptionRate;

    //[SerializeField] float coalConsumptionMod;

    //[SerializeField] float accelerationRate;
    [SerializeField] int targetEnginePower;

    Coroutine speedChange;

    [SerializeField] WagonClassifier wagonClassifier;
    [SerializeField] SpeedHandle speedHandle;

    Inventory inventory;
    [SerializeField] float reactionDelay;
    [SerializeField] private int trainSpeedModifier;
    private float zeroSpeed;

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        wagonClassifier.Speed = trainSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if(trainSpeed>0 && !engineAudioSource.isPlaying)
        {
            engineAudioSource.Play();
        }
        //ConsumeCoal(coalStock);

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

    public void SpeedChanged(int value )
        {
                if(speedChange != null)
                {
                    StopCoroutine(speedChange);
                    speedChange = null;
                }
                if(breakTrainOverTime.TrainBroken)
                {
                    zeroSpeed = 0f;
                }
                else
                {
                    zeroSpeed = 1f;
                }
   
                if(value>0)
                {
                speedChange = StartCoroutine(FuelToEngine(value * trainSpeedModifier * zeroSpeed));
                PlayTrainAcelerationSFX();

                }
                else
                {
                    speedChange =  StartCoroutine(FuelToEngine(value * zeroSpeed));
                    PlayTrainAcelerationSFX();
                }

        }

    private void PlayTrainAcelerationSFX()
    {
        if (!trainAudioSource.isPlaying)
        {
            trainAudioSource.PlayOneShot(musicContainer.audioClips[6]);
        }
    }

    void OnDisable()
    {
        speedHandle.HandleMoved -= SpeedChanged;
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
        //coalConsumptionRate += coalConsumption;
        coalConsumptionRate = coalConsumption;
        //float target = trainSpeed + coalConsumptionRate * accelerationRate;
        //float target = trainSpeed + coalConsumptionRate;
        float target = coalConsumptionRate;

        Debug.Log("Target speed is: " + target.ToString());

        while(timeElapsed<reactionDelay)
        {
            timeElapsed += Time.deltaTime;
            wagonClassifier.Speed = Mathf.Lerp(trainSpeed, target, timeElapsed/reactionDelay);
            yield return null;
        }
        wagonClassifier.Speed = target;
        trainSpeed = target;
    }

    // IEnumerator ReleaseSteamFromEngine(float coalConsumption)
    // {
    //     float timeElapsed=0f;
    //     coalConsumptionRate -= coalConsumption;
    //     float target = trainSpeed - (coalConsumptionRate * accelerationRate);


    //     while(timeElapsed<reactionDelay)
    //     {
    //         wagonClassifier.Speed = Mathf.Lerp(trainSpeed, target, timeElapsed/reactionDelay);
    //         timeElapsed += Time.deltaTime;
    //         yield return null;
    //     }
    //     wagonClassifier.Speed = target;
    // }

        IEnumerator StopEngine()
    {
        float timeElapsed=0f;
        float target = 0f;

        while(timeElapsed<reactionDelay)
        {
            wagonClassifier.Speed = Mathf.Lerp(wagonClassifier.Speed, target, timeElapsed/reactionDelay);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        wagonClassifier.Speed = target;
        trainSpeed = target;
    }

}
