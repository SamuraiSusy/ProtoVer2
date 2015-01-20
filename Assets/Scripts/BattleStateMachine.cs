using UnityEngine;
using System.Collections;

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

    private BattleStates currentState;

    private float screenCenterX, screenCenterY;
    private float menuPosX, menuPosY;
    private float buttonPosX, buttonPosY, buttonWidth, buttonHeight;

    public GUIText allyName, allyHP, enemyName, enemyHP;
    public int allyHPAmount, enemyHPAmount;

    public int baseDmg, enemyBaseDmg, dmg1, eDmg1;

    private float x, y, w, h;
    private string potName;
    public GameObject PlayerInventory;

	// Use this for initialization
	void Start ()
    {
        currentState = BattleStates.START;

        screenCenterX = Screen.width / 2;
        screenCenterY = Screen.height / 2;
        menuPosX = screenCenterX - 300;
        menuPosY = screenCenterY + 60;
        buttonPosX = menuPosX + 20;
        buttonPosY = menuPosY + 20;
        buttonWidth = 60;
        buttonHeight = 40;

        PlayerInventory = GameObject.FindWithTag("PlayerInventory");
	}
	
	 // Update is called once per frame
    void Update ()
    {
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
        DrawPlayerInformation();
        DrawEnemyInformation();
        if(currentState == BattleStates.PLAYERCHOISE)
        {
            GUI.Box(new Rect(menuPosX, menuPosY, screenCenterX / 1.5f, screenCenterY / 1.5f), "Menu");
            if (GUI.Button(new Rect(buttonPosX, buttonPosY, buttonWidth, buttonHeight), "Attack"))
            {
                currentState = BattleStates.ATTACK;
            }
            else if (GUI.Button(new Rect(buttonPosX + 80f, buttonPosY, buttonWidth, buttonHeight), "Monster"))
            {

            }
            else if (GUI.Button(new Rect(buttonPosX, buttonPosY + 80f, buttonWidth, buttonHeight), "Items"))
            {
                currentState = BattleStates.USEITEM;
            }
            else if (GUI.Button(new Rect(buttonPosX + 80f, buttonPosY + 80f, buttonWidth, buttonHeight), "Run"))
            {

            }
        }
        else if (currentState == BattleStates.ATTACK)
        {
            if (allyHPAmount > 0)
                Attack();
            else if (allyHPAmount <= 0)
            {
                allyHPAmount = 0;
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
            // enemy attacks, uses items etc.
        }
        else if(currentState == BattleStates.ENEMYCHOISE)
        {
            if(enemyHPAmount > 0)
            {
                EnemyAttack();
                Invoke("ChangeToPlayerChoise", 3f);
            }
            else if(enemyHPAmount <= 0)
            {
                enemyHPAmount = 0;
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

    void DrawPlayerInformation()
    {
        allyHP.text = "HP: " + allyHPAmount;
    }

    void DrawEnemyInformation()
    {
        enemyHP.text = "HP: " + enemyHPAmount;
    }

    void Attack()
    {
        if(currentState == BattleStates.ATTACK)
        {
            GUI.Box(new Rect(menuPosX, menuPosY, screenCenterX / 1.5f, screenCenterY / 1.5f), "Menu");
            if (GUI.Button(new Rect(buttonPosX, buttonPosY, buttonWidth, buttonHeight), "Attack1"))
            {
                enemyHPAmount -= (baseDmg + dmg1);
                currentState = BattleStates.ENEMYCHOISE;
            }
            else if (GUI.Button(new Rect(buttonPosX + 80f, buttonPosY, buttonWidth, buttonHeight), "Attack2"))
            {
                Debug.Log("sait kauniin viestin");
                currentState = BattleStates.ENEMYCHOISE;
            }
            else if (GUI.Button(new Rect(buttonPosX, buttonPosY + 80f, buttonWidth, buttonHeight), "Def"))
            {
                if (enemyBaseDmg > 10)
                {
                    enemyBaseDmg -= 3;
                    Debug.Log("enemy's base dmg dropped 5");
                }
                else
                    Debug.Log("enemy's base damage cannot go lower");

                currentState = BattleStates.ENEMYCHOISE;
            }
            else if (GUI.Button(new Rect(buttonPosX + 80f, buttonPosY + 80f, buttonWidth, buttonHeight), "Return"))
            {
                currentState = BattleStates.PLAYERCHOISE;
            }
        }
    }

    void EnemyTurn()
    {
        Debug.Log("enemy's turn");
        if(allyHPAmount > 0)
        {
            if(enemyHPAmount > 30)
            {
                EnemyAttack();
            }
            else
            {
                EnemyUseItem();
            }
            ChangeToPlayerChoise();
        }
        else if(allyHPAmount <= 0)
        {
            allyHPAmount = 0;
            currentState = BattleStates.LOSE;
        }  
    }
    
    void EnemyAttack()
    {
        float whichChoise = Random.Range(1, 4);
        Debug.Log("which choise: " + whichChoise);
        if(whichChoise > 1.5f)
        {
            allyHPAmount -= (enemyBaseDmg + eDmg1);
            Debug.Log("enemy attacked");
        }
        else if(whichChoise <= 1.5f)
        {
            if (baseDmg > 7)
                baseDmg -= 2;
            else
                Debug.Log("ally base damage cannot go lower");
        }

        if (allyHPAmount > 0)
            ChangeToPlayerChoise();
        else
        {
            allyHPAmount = 0;
            currentState = BattleStates.LOSE;
        }
    }

    void EnemyUseItem()
    {
        Debug.Log("enemy should use potion");
        EnemyAttack();
        ChangeToPlayerChoise();
    }

    void ChangeToPlayerChoise()
    {
        currentState = BattleStates.PLAYERCHOISE;
    }
}