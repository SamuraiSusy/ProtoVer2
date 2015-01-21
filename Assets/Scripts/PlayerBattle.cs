using UnityEngine;
using System.Collections;
using System.Linq;

public class PlayerBattle : MonoBehaviour
{
    public GameObject GUIThings, StateMachine, BattleEnemy, PlayerInventory;

    public int allyHPAmount;
    public int baseDmg, dmg1;

    // Use this for initialization
    void Start()
    {
        GUIThings = GameObject.FindWithTag("GUI");
        StateMachine = GameObject.FindWithTag("BattleState");
        BattleEnemy = GameObject.FindWithTag("EnemyBattle");
        PlayerInventory = GameObject.FindWithTag("PlayerInventory");
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

        bool isEmpty = !playerInventory.playerItemsID.Any();
        float offSet = 0;

        // EI TOIMI
        for (int i = playerInventory.playerItemsID.Count - 1; i >= 0; i--)
        {
            if(GUI.Button(new Rect(Screen.width / 2 - 100, 20 + offSet, 100, 20), playerInventory.pot1.PotionName))
            {
                if(isEmpty == false)
                {
                    Debug.Log("deleted");
                    playerInventory.playerItemsName.RemoveAt(0);
                }
                else
                {
                    BattleStateMachine stateMachine = StateMachine.GetComponent<BattleStateMachine>();
                    stateMachine.ChangeToPlayerChoise();
                }
            }
            offSet += 25;
        }
    }

    public void ChangeMonster()
    {
        Debug.Log("change that babyy");
    }

    void InventoryCount()
    {
        PlayerInventory playerInventory = PlayerInventory.GetComponent<PlayerInventory>();

        Debug.Log(playerInventory.playerItemsID.Count);
    }
}