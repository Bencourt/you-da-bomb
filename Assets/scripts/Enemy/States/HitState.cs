using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : BaseState
{
    private float ragdollTimer = 3.0f;
    public override void Enter()
    {
        ragdollTimer = 3.0f;
        foreach (Rigidbody rb in enemy.ragdollRB)
        {
            rb.isKinematic = false;
        }
        foreach (Collider c in enemy.ragdollCollider)
        {
            if (!c.isTrigger)
            {
                c.enabled = true;
            }
        }
        enemy.animator.enabled = false;
    }
    public override void Perform()
    {
        ragdollTimer -= Time.deltaTime;
        if(ragdollTimer < 0 )
        {
            stateMachine.ChangeState(stateMachine.trackState);
        }
    }
    public override void Exit()
    {
        foreach (Rigidbody rb in enemy.ragdollRB)
        {
            rb.isKinematic = true;
        }
        foreach (Collider c in enemy.ragdollCollider)
        {
            if (!c.isTrigger)
            {
                c.enabled = false;
            }
        }
        enemy.animator.enabled = true;
    }
}
