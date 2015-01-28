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
        int n = 0;
        PlayerInventory playerInventory = PlayerInventory.GetComponent<PlayerInventory>();

        BattleStateMachine stateMachine = StateMachine.GetComponent<BattleStateMachine>();
        InventoryCount(); // debug function

        bool isEmpty = !playerInventory.playerItemsID.Any();
        float offSet = 0;

        // TÄÄ ALKAA TEKEE BUTTONEI IKUISEST VAIK playerInventory.playerItemsID.Count ON KOKO AJA 3
        //for (int i = 0; i < /*playerInventory.playerItemsID.Count*/3; i++)
        //{
        //    invButtons.Add(GUI.Button(new Rect(Screen.width / 2.5f, Screen.height / 5.1f + offSet + i, 100, 50), playerInventory.pot1.PotionName));
        //    offSet += 60;

        //    Debug.Log(invButtons.Count);
        //}
        // SAMA TAPAHTUU TÄÄL, TON PITÄIS OL KOLME MUT LOOPPAA IKUISEST
        //while (n < 3)
        //{
        //    invButtons.Add(GUI.Button(new Rect(Screen.width / 2.5f, Screen.height / 5.1f + offSet, 100, 50), playerInventory.pot1.PotionName));
        //    offSet += 60;

        //    Debug.Log("invbutton count " + invButtons.Count);
        //    Debug.Log("playeritemsid count " + playerInventory.playerItemsID.Count);
        //    Debug.Log("n " + n);
        //    n++;
        //}
        for (int i = 0; i < 3; i++)
        {
            if (i < 3)
            {
                invButtons.Add(GUI.Button(new Rect(Screen.width / 2.5f, Screen.height / 5.1f + offSet, 100, 50), playerInventory.pot1.PotionName));
                offSet += 60;
            }
            else
                break;

            Debug.Log("invbutton count " + invButtons.Count);
            Debug.Log("playeritemsid count " + playerInventory.playerItemsID.Count);
            Debug.Log("n " + i);
        }
            foreach (bool buttons in invButtons)
            {
                if (buttons)
                {
                    invButtons.RemoveAt(0);
                }
            }
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