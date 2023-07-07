using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakTrainOverTime : MonoBehaviour
{
    [SerializeField] InventorySlot[] slotsInManteinanceInv;
    [SerializeField] PressureLevel pressureLevel;
    [SerializeField] TrainSpeedController trainSpeedController;
    [SerializeField] AudioSource manteinanceAudioSource; 
    [SerializeField] ContainMusic musicContainer;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] int breakDC;
    [SerializeField] bool checkTrainMoving;
    [SerializeField] float engineCheckCooldown;

    [SerializeField] int minDC;
    [SerializeField] int midDC;
    [SerializeField] int maxDC;
    [SerializeField] float currentTime;

    [SerializeField] bool trainBroken;
    public bool TrainBroken { get{ return trainBroken;}}
    // Start is called before the first frame update
    void Start()
    {
        trainBroken = false;

    }

    // Update is called once per frame
    void Update()
    {
        CheckEngineState(engineCheckCooldown);
        CheckGearInInventory();
    }

    private void CheckGearInInventory()
    {
        if(GetGearEquipped(slotsInManteinanceInv)!= null)
        {
            trainBroken = false;
        }
        else
        {
            trainBroken = true;
        }
    }

    public void CheckEngineState(float cooldown)
    {
            currentTime += Time.deltaTime;

            if(cooldown<=currentTime && trainSpeedController.TrainSpeed>0f)
            {
            int diceRes = throwDice();
            int breakDC = BreakDC(pressureLevel, minDC,midDC,maxDC);
            //Debug.Log("dice result: " + diceRes.ToString());

                if(diceRes >= breakDC)
                {
                    //trainBroken = false;
                    //Debug.Log("Egine fail "+"Break DC "+ breakDC.ToString()+" Dice result: "+diceRes.ToString());
                    DestroyGear();
                }
                else
                {
                    //Debug.Log("Nothing happens");
                } 

            currentTime = 0;
            }

    }

    private void DestroyGear()
    {
        DraggableItem itemSelected = GetGearEquipped(slotsInManteinanceInv);
        if(itemSelected != null)
        {
            //trainBroken = false;
            
            DestroyGearEquipped(itemSelected);
            manteinanceAudioSource.PlayOneShot(musicContainer.audioClips[9]);
        }
        else
        {
            WithoutGearsStopEngine();
        }
        
    }

    private void WithoutGearsStopEngine()
    {
        //Debug.Log("STOPPING ENGINE NO SPARE PARTS LEFT");
        trainBroken = true;
    }

    private void DestroyGearEquipped(DraggableItem itemSelected)
    {
        Destroy(itemSelected.gameObject);
        
    }

    private DraggableItem GetGearEquipped(InventorySlot[] listItemsActive)
    {
        for(int i = 0; i < listItemsActive.Length; i++)
        {
            if(listItemsActive[i].GetComponentInChildren<DraggableItem>() != null)
            {

                return listItemsActive[i].GetComponentInChildren<DraggableItem>();
            }
        }
        return null;
    }

    private int BreakDC(PressureLevel pressure, int minDc, int midDc,int maxDc)
    {

        float pressureRatio = pressure.CurrentPressure/pressure.MaxPressure;

        if(pressureRatio>=0.9f)
        {
            return minDc;
        }
        else if(pressureRatio < 0.9f & pressureRatio>=0.6)
        {
            return midDc;
        }

        else
        {
            return maxDc;
        }

    }

    int throwDice()
    {
        int rnd = Random.Range(1,20);
        return rnd;
    }
}
