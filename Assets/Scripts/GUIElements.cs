using UnityEngine;
using System.Collections;

public class GUIElements : MonoBehaviour
{
    public float screenCenterX, screenCenterY;
    public float menuPosX, menuPosY;
    public float buttonPosX, buttonPosY, buttonWidth, buttonHeight;

    public GUIText allyName, allyHP, enemyName, enemyHP;

    public GameObject StateMachine, BattlePlayer, BattleEnemy;

	// Use this for initialization
	void Start ()
    {
        screenCenterX = Screen.width / 2;
        screenCenterY = Screen.height / 2;
        menuPosX = screenCenterX - 300;
        menuPosY = screenCenterY + 60;
        buttonPosX = menuPosX + 20;
        buttonPosY = menuPosY + 20;
        buttonWidth = 60;
        buttonHeight = 40;

        StateMachine = GameObject.FindWithTag("BattleState");
        BattlePlayer = GameObject.FindWithTag("PlayerBattle");
        BattleEnemy = GameObject.FindWithTag("EnemyBattle");
	}
	
	// Update is called once per frame
	void Update ()
    {
        BattleStateMachine stateMachine = StateMachine.GetComponent<BattleStateMachine>();

        if(stateMachine.currentState == BattleStateMachine.BattleStates.ENEMYCHOISE ||
            stateMachine.currentState == BattleStateMachine.BattleStates.PLAYERCHOISE)
        {
            DrawPlayerInformation();
            DrawEnemyInformation();
        }
        else
        {
            Debug.Log("lololo");
        }
	}

    void DrawPlayerInformation()
    {
        PlayerBattle playerBattle = BattlePlayer.GetComponent<PlayerBattle>();
        allyHP.text = "HP: " + playerBattle.allyHPAmount;
    }

    void DrawEnemyInformation()
    {
        EnemyBattle enemyBattle = BattleEnemy.GetComponent<EnemyBattle>();
        enemyHP.text = "HP: " + enemyBattle.enemyHPAmount;
    }
}
