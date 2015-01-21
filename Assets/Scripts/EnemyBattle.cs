using UnityEngine;
using System.Collections;

public class EnemyBattle : MonoBehaviour
{
    public GameObject GUIThings, StateMachine, BattlePlayer;

    public int enemyHPAmount;
    public int enemyBaseDmg, eDmg1;

	// Use this for initialization
	void Start ()
    {
        GUIThings = GameObject.FindWithTag("GUI");
        StateMachine = GameObject.FindWithTag("BattleState");
        BattlePlayer = GameObject.FindWithTag("PlayerBattle");
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void EnemyTurn()
    {
        BattleStateMachine stateMachine = StateMachine.GetComponent<BattleStateMachine>();
        PlayerBattle playerBattle = BattlePlayer.GetComponent<PlayerBattle>();

        Debug.Log("enemy's turn");
        if (playerBattle.allyHPAmount > 0)
        {
            if (enemyHPAmount > 30)
            {
                EnemyAttack();
            }
            else
            {
                EnemyUseItem();
            }
            stateMachine.ChangeToPlayerChoise();
        }
        else if (playerBattle.allyHPAmount <= 0)
        {
            playerBattle.allyHPAmount = 0;
            stateMachine.currentState = BattleStateMachine.BattleStates.LOSE;
        }  
    }

    void EnemyAttack()
    {
        BattleStateMachine stateMachine = StateMachine.GetComponent<BattleStateMachine>();
        PlayerBattle playerBattle = BattlePlayer.GetComponent<PlayerBattle>();

        float whichChoise = Random.Range(1, 4);
        Debug.Log("which choise: " + whichChoise);
        if (whichChoise > 1.5f)
        {
            playerBattle.allyHPAmount -= (enemyBaseDmg + eDmg1);
            Debug.Log("enemy attacked");
        }
        else if (whichChoise <= 1.5f)
        {
            if (playerBattle.baseDmg > 5)
                playerBattle.baseDmg -= 2;
            else
                Debug.Log("ally base damage cannot go lower");
        }

        if (playerBattle.allyHPAmount > 0)
            stateMachine.ChangeToPlayerChoise();
        else
        {
            playerBattle.allyHPAmount = 0;
            stateMachine.currentState = BattleStateMachine.BattleStates.LOSE;
        }
    }

    void EnemyUseItem()
    {
        BattleStateMachine stateMachine = StateMachine.GetComponent<BattleStateMachine>();

        Debug.Log("enemy should use potion");
        EnemyAttack();
        stateMachine.ChangeToPlayerChoise();
    }
}
