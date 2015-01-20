using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> playerItems;
    public BasePotion pot1;
    public List<string> playerItemsName;

    public static int potionAmount = 10;

	// Use this for initialization
	void Start ()
    {
        pot1 = new BasePotion();
        pot1.PotionName = "Small Potion";
        pot1.PotionType = BasePotion.PotionTypes.HP;
        pot1.HealAmount = 20;

        BasePotion[] pots = new BasePotion[potionAmount];
        pots[0] = pot1;
        pots[1] = pot1;
        pots[2] = pot1;

        playerItems = new List<Item>(pots);

        string[] potsName = new string[potionAmount];
        potsName[0] = pot1.PotionName;
        potsName[1] = pot1.PotionName;
        potsName[2] = pot1.PotionName;

        playerItemsName = new List<string>(potsName);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
