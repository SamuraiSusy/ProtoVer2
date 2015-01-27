using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class PlayerBattle : MonoBehaviour
{
    public GameObject GUIThings, StateMachine, BattleEnemy, PlayerInventory;

    private int allyMaxHP;
    public int allyHPAmount;
    public int baseDmg, dmg1;

    private bool isButtonPressed;
    private bool[] inventoryButtons;
    private List<bool> invButtons;
    

    // Use this for initialization
    void Start()
    {

        GUIThings = GameObject.FindWithTag("GUI");
        StateMachine = GameObject.FindWithTag("BattleState");
        BattleEnemy = GameObject.FindWithTag("EnemyBattle");
        PlayerInventory = GameObject.FindWithTag("PlayerInventory");


        PlayerInventory playerInventory = PlayerInventory.GetComponent<PlayerInventory>();

        allyMaxHP = 55;
        isButtonPressed = false;

        invButtons = new List<bool>(playerInventory.playerItemsID.Count);
        Debug.Log(invButtons.Count);
    }

    // Update is called once per frame
    void Update()
    {
        InventoryCount();
    }

    public void Attack()
    {
        GUIElements guiElements = GUIThings.GetComponent<GUIElements>();
        BattleStateMachine stateMachine = StateMachine.GetComponent<BattleStateMachine>();
        EnemyBattle enemyBattle = BattleEnemy.GetComponent<EnemyBattle>();

        GUI.Box(new Rect(guiElements.menuPosX, guiElements.menuPosY, guiElements.screenCenterX / 1.5f, guiElements.screenCenterY / 1.5f), "Menu");
        if (GUI.Button(new Rect(guiElements.buttonPosX, guiElements.buttonPosY, guiElements.buttonWidth, guiElements.buttonHeight), "Attack1"))
        {
            enemyBattle.enemyHPAmount -= (baseDmg + dmg1);
            stateMachine.currentState = BattleStateMachine.BattleStates.ENEMYCHOISE;
        }
        else if (GUI.Button(new Rect(guiElements.buttonPosX + 80f, guiElements.buttonPosY, guiElements.buttonWidth, guiElements.buttonHeight), "Attack2"))
        {
            Debug.Log("sait kauniin viestin");
            stateMachine.currentState = BattleStateMachine.BattleStates.ENEMYCHOISE;
        }
        else if (GUI.Button(new Rect(guiElements.buttonPosX, guiElements.buttonPosY + 80f, guiElements.buttonWidth, guiElements.buttonHeight), "Def"))
        {
            if (enemyBattle.enemyBaseDmg > 5)
            {
                enemyBattle.enemyBaseDmg -= 3;
                Debug.Log("enemy's base dmg dropped 5");
            }
            else
                Debug.Log("enemy's base damage cannot go lower");

            stateMachine.currentState = BattleStateMachine.BattleStates.ENEMYCHOISE;
        }
        else if (GUI.Button(new Rect(guiElements.buttonPosX + 80f, guiElements.buttonPosY + 80f, guiElements.buttonWidth, guiElements.buttonHeight), "Return"))
        {
            stateMachine.currentState = BattleStateMachine.BattleStates.PLAYERCHOISE;
        }
    }

    public void UseItem()
    {
        PlayerInventory playerInventory = PlayerInventory.GetComponent<PlayerInventory>();

        BattleStateMachine stateMachine = StateMachine.GetComponent<BattleStateMachine>();
        InventoryCount(); // debug function

        bool isEmpty = !playerInventory.playerItemsID.Any();
        float offSet = 0;

        for (int i = 0; i < playerInventory.playerItemsID.Count; i++)
        {
            invButtons.Add(GUI.Button(new Rect(Screen.width / 2.5f, Screen.height / 5.1f + offSet + i, 100, 50), playerInventory.pot1.PotionName));
            offSet += 60;
            Debug.Log(i);
        }
        foreach(bool but in invButtons)
        {
            if (but)
            {
                Debug.Log("yay");
            }
            if (GUI.Button(new Rect(10, 10, 10, 10), "lo"))
            {
                Debug.Log("lolo");
            }
            // no ei ittu toimi
        }
        stateMachine.currentState = BattleStateMachine.BattleStates.PLAYERCHOISE;
        //invButtons.Add(GUI.Button(new Rect(Screen.width / 2.5f, Screen.height / 5.1f + offSet, 100, 50), playerInventory.pot1.PotionName));
        //Debug.Log("inv buttons count " + invButtons.Count);


    }

    public void ChangeMonster()
    {
        Debug.Log("change that babyy");
    }

    void InventoryCount()
    {
        PlayerInventory playerInventory = PlayerInventory.GetComponent<PlayerInventory>();

        Debug.Log("in player inventory: " + playerInventory.playerItemsID.Count);
    }

    void AddToInventory()
    {
        // if the player finds items...
    }
}