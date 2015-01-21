using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> playerItems;
    public BasePotion pot1;
    public List<string> playerItemsName;
    public List<int> playerItemsID;

    public static int potionAmount = 10;

	// Use this for initialization
	void Start ()
    {
        pot1 = new BasePotion();
        pot1.PotionName = "Small Potion";
        pot1.PotionType = BasePotion.PotionTypes.HP;
        pot1.HealAmount = 20;
        pot1.PotionID = 10;

        //playerItems = new List<Item>(pots);

        //playerItemsName = new List<string>(potsName);
        playerItemsName = new List<string>();
        playerItemsName.Add(pot1.PotionName); 
        playerItemsName.Add(pot1.PotionName);
        playerItemsName.Add(pot1.PotionName);

        playerItemsID = new List<int>();
        playerItemsID.Add(pot1.PotionID);
        playerItemsID.Add(pot1.PotionID);
        playerItemsID.Add(pot1.PotionID);

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
