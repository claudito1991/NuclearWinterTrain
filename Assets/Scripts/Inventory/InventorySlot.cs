using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] ContainMusic musicContainer;
    [SerializeField] AudioSource boilerAudioSource;
    [SerializeField] AudioSource manteinanceAudioSource;

    public static Action <int> AddCoalToInventory;
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
        }

        if(transform.GetComponent<InventoryBoiler>())
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            
            if(draggableItem.itemType != ItemType.Energy)
            {
                Destroy(dropped);
            }
            int coal = dropped.GetComponent<DraggableItem>().count;
            draggableItem.parentAfterDrag = transform;
            AddCoalToInventory?.Invoke(coal);
            boilerAudioSource.PlayOneShot(musicContainer.audioClips[0]);
            Destroy(dropped);
            //Debug.Log("IN BOILER " + coal.ToString());

        }
            if(transform.GetComponent<MaintenanceInventory>())
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            manteinanceAudioSource.PlayOneShot(musicContainer.audioClips[9]);
            if(draggableItem.itemType != ItemType.SpareParts)
            {
                Destroy(dropped);
            }
            //int coal = dropped.GetComponent<DraggableItem>().count;
            draggableItem.parentAfterDrag = transform;
            //Destroy(dropped);
            
            Debug.Log("In Manteinance ");

        }

        if(transform.GetComponent<StationInventory>())
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            int coal = dropped.GetComponent<DraggableItem>().count;
            draggableItem.parentAfterDrag = transform;
            //Debug.Log("IN STATION " + coal.ToString());

        }

      

    }
}
