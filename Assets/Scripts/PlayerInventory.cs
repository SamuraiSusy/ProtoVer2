using UnityEngine;
using System.Collections;
using System.Linq;
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

        // maybe have to do list for every item separately
        // OR DO ONE DICTIONARY :OOO maybe? n.n
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
