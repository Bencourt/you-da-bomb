using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private bool isMoving;
    public override void Enter()
    {

    }
    public override void Perform()
    {
        attackState();
    }
    public override void Exit()
    {

    }

    public void attackState()
    {
        enemy.GetComponent<Animator>().SetBool("IsMoving", false);
        enemy.Agent.SetDestination(enemy.player.position);
        if (enemy.Agent.remainingDistance > 2)
        {
            enemy.GetComponent<Animator>().SetBool("IsMoving", true);
            stateMachine.ChangeState(stateMachine.trackState);
        }
    }
}
