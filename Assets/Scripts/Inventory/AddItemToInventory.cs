using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemToInventory : MonoBehaviour
{
    public InventoryManager trainInventory;

    public InventoryManager stationInventory;

    public inventoryType currentInventory; 
    public Item itemToPickUp;

    public AudioSource thisAudioSource;
    public ContainMusic musicContainer;
    public enum inventoryType{
        TRAIN, 
        STATION
    }
    public coal coal;


    void Start()
    {
        //trainInventory = FindObjectOfType<InventoryManager>();
        trainInventory = GameObject.FindWithTag("train").GetComponent<InventoryManager>();
        stationInventory = GameObject.FindWithTag("station").GetComponent<InventoryManager>();
        musicContainer = FindObjectOfType<ContainMusic>();
    }
    // Start is called before the first frame update
    
    // void OnMouseDown()
    // {
    //     if(currentInventory == inventoryType.TRAIN)
    //     {
            
    //         trainInventory.AddItem(itemToPickUp,coal);
    //         Debug.Log("wrong code");
    //     }
    // }

    public void AddThisItemToTrain()
    {
        thisAudioSource.PlayOneShot(musicContainer.audioClips[7]);
        trainInventory.AddItem(itemToPickUp,coal); 
        
        //Debug.Log("here");
    }

    public void GenerateItemOnStation()
    {
        if(currentInventory == inventoryType.STATION)
        {
            stationInventory.AddItem(itemToPickUp,coal);
        }
    }


}
