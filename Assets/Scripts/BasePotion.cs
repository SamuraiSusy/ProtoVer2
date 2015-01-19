using UnityEngine;
using System.Collections;

public class BasePotion : Item
{
    private string potionName;
    private int potionID;
    private int healAmount;

    public enum PotionTypes
    {
        HP,
        MANA
    }

    private PotionTypes potionType;

    public PotionTypes PotionType
    {
        get { return potionType; }
        set { potionType = value; }
    }

    public string PotionName
    {
        get { return potionName; }
        set { potionName = value; }
    }

    public int PotionID
    {
        get { return potionID; }
        set { potionID = value; }
    }

    public int HealAmount
    {
        get { return healAmount; }
        set { healAmount = value; }
    }
}