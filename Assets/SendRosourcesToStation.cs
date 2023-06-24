using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SendRosourcesToStation : MonoBehaviour
{
        
    [SerializeField] InventorySlot[] stationInvSlots;
    [SerializeField] List<DraggableItem> itemsInInv;
    StationData stationData;
    StationController stationController;

    public Button sendResButton;




    // Start is called before the first frame update
    void Start()
    {
        stationData = GetComponent<StationData>();
        stationController = GetComponent<StationController>();


        
    }

    public void AssignThisButton()
    {
        
            UnityEngine.Events.UnityAction miAccion = AddItemsToInventory;
            sendResButton.onClick.RemoveAllListeners();
            //Debug.Log("Listener removed");
            sendResButton.onClick.AddListener(miAccion);
            //Debug.Log("Listener added");
        

    }


    // Update is called once per fram

        public void AddItemsToInventory()
    {
        
        if(!stationController.StationInvIsActive)
        {
            return;
        }

        for(int i = 0; i < stationInvSlots.Length; i++)
        {
            DraggableItem currentItem = stationInvSlots[i].GetComponentInChildren<DraggableItem>();
            itemsInInv.Add(currentItem);
        }

        foreach(DraggableItem item in itemsInInv)
        {
            if(item != null)
            {
                Debug.Log(item.count.ToString());
                stationData.AddCoalInStation(item.count);
                stationData.GenerateRewardAmount();
                Destroy(item.gameObject);
            }
            
        }
    }
}
