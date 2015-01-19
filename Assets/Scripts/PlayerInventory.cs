using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> playerItems;
    public BasePotion pot1;

    public static int potionAmount = 10;
	// Use this for initialization
	void Start ()
    {
        //pot1 = new BasePotion();
        //pot1.PotionName = "Small Potion";
        //pot1.PotionType = BasePotion.PotionTypes.HP;

        BasePotion[] pots = new BasePotion[potionAmount];
        pots[0].PotionName = "Small Potion";
        pots[0].PotionType = BasePotion.PotionTypes.HP;
        pots[0].HealAmount = 20;

        playerItems = new List<Item>(pots);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
