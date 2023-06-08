using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    [Header("Only gameplay")]
    public ItemType type;
    public ActionType actionType;
    public int minAmount;
    public int maxAmount;

    public int amount;

    [Header("Only UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;

    void Start()
    {
        if(type == ItemType.Energy)
        {
            amount = Random.Range(minAmount, maxAmount);
        }
    }

}

public enum ItemType{
    Energy,
    People,
    SpareParts
}

public enum ActionType{
    Store, 
    Consume
}
