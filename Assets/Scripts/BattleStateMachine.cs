using UnityEngine;
using System.Collections;

// MAYBE CHANGE THIS CLASS TO STATIC???????

public class BattleStateMachine : MonoBehaviour
{
    public enum BattleStates
    {
        START,
        PLAYERCHOISE,
        ATTACK,
        USEITEM,
        CHANGEMONSTER,
        ENEMYCHOISE,
        RUN,
        WIN,
        LOSE
    }

    public BattleStates currentState;

    public GameObject GUIThings, BattlePlayer, BattleEnemy, PlayerInventory;

	// Use this for initialization
	void Start ()
    {
        currentState = BattleStates.START;

        GUIThings = GameObject.FindWithTag("GUI");
        BattlePlayer = GameObject.FindWithTag("PlayerBattle");
        BattleEnemy = GameObject.FindWithTag("EnemyBattle");
        PlayerInventory = GameObject.FindWithTag("PlayerInventory");
	}
	
	 // Update is called once per frame
    void Update ()
    {
        // OnGUI things here??
        Debug.Log(currentState);
        switch(currentState)
        {
            case BattleStates.START:
                //
                break;
            case BattleStates.PLAYERCHOISE:
                //
                break;
            case BattleStates.USEITEM:
                //
                break;
            case BattleStates.CHANGEMONSTER:
                //
                break;
            case BattleStates.ENEMYCHOISE:
                //
                break;
            case BattleStates.RUN:
                //
                break;
            case BattleStates.WIN:
                //
                break;
            case BattleStates.LOSE:
                //
                break;
        }

        if (currentState == BattleStates.START)
            currentState = BattleStates.PLAYERCHOISE;
    }

    void OnGUI()
    {
        GUIElements guiElements = GUIThings.GetComponent<GUIElements>();
        PlayerBattle playerBattle = BattlePlayer.GetComponent<PlayerBattle>();
        EnemyBattle enemyBattle = BattleEnemy.GetComponent<EnemyBattle>();

        if(currentState == BattleStates.PLAYERCHOISE)
        {
            GUI.Box(new Rect(guiElements.menuPosX, guiElements.menuPosY, guiElements.screenCenterX / 1.5f, guiElements.screenCenterY / 1.5f), "Menu");
            if (GUI.Button(new Rect(guiElements.buttonPosX, guiElements.buttonPosY, guiElements.buttonWidth, guiElements.buttonHeight), "Attack"))
            {
                currentState = BattleStates.ATTACK;
            }
            else if (GUI.Button(new Rect(guiElements.buttonPosX + 80f, guiElements.buttonPosY, guiElements.buttonWidth, guiElements.buttonHeight), "Monster"))
            {

            }
            else if (GUI.Button(new Rect(guiElements.buttonPosX, guiElements.buttonPosY + 80f, guiElements.buttonWidth, guiElements.buttonHeight), "Items"))
            {
                currentState = BattleStates.USEITEM;
            }
            else if (GUI.Button(new Rect(guiElements.buttonPosX + 80f, guiElements.buttonPosY + 80f, guiElements.buttonWidth, guiElements.buttonHeight), "Run"))
            {

            }
        }
        else if (currentState == BattleStates.ATTACK)
        {
            if (playerBattle.allyHPAmount > 0)
                playerBattle.Attack();
            else if (playerBattle.allyHPAmount <= 0)
            {
                playerBattle.allyHPAmount = 0;
                Debug.Log("you lost");
            }
        }
        else if (currentState == BattleStates.USEITEM)
        {
            PlayerInventory playerInventory;
            playerInventory = PlayerInventory.GetComponent<PlayerInventory>();
            float offSet = 0;
            foreach (string i in playerInventory.playerItemsName)
            {
                if(GUI.Button(new Rect(20, 20 + offSet, 100, 20), i))
                {
                    // chack if there is still pots
                    playerInventory.playerItemsName.RemoveAt(0);
                }
                offSet += 25;
            }
        }
        else if (currentState == BattleStates.CHANGEMONSTER)
        {
            //
        }
        else if(currentState == BattleStates.ENEMYCHOISE)
        {
            if (enemyBattle.enemyHPAmount > 0)
            {
                enemyBattle.EnemyTurn();
                Invoke("ChangeToPlayerChoise", 3f);
            }
            else if (enemyBattle.enemyHPAmount <= 0)
            {
                enemyBattle.enemyHPAmount = 0;
                currentState = BattleStates.WIN;
            }
        }
        else if (currentState == BattleStates.WIN)
        {
            Debug.Log("you won");
        }
        else if (currentState == BattleStates.LOSE)
        {
            Debug.Log("you lost");
        }
    }

    public void ChangeToPlayerChoise()
    {
        currentState = BattleStates.PLAYERCHOISE;
    }
}