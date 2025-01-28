using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackState : BaseState
{
    public override void Enter()
    {

    }
    public override void Perform()
    {
        TrackPlayer();
    }
    public override void Exit()
    {

    }

    public void TrackPlayer()
    {
        if(enemy.Agent.remainingDistance < 2)
        {
            stateMachine.ChangeState(stateMachine.attackState);
        }
        enemy.Agent.SetDestination(enemy.player.position);
    }
}
