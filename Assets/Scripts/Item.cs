using UnityEngine;
using System.Collections;

public class Item
{
    private string itemName;
    private int itemID;

    public enum ItemTypes
    {
        POTION
    }

    private ItemTypes itemType;
    public ItemTypes ItemType
    {
        get { return itemType; }
        set { itemType = value; }
    }

    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }

    public int ItemID
    {
        get { return itemID; }
        set { itemID = value; }
    }
}