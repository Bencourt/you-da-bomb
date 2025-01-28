using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    public PatrolState patrolState;
    public TrackState trackState;
    public AttackState attackState;
    public HitState hitState;
    // Start is called before the first frame update

    public void Initialize()
    {
        patrolState= new PatrolState();
        trackState= new TrackState();
        attackState= new AttackState();
        hitState= new HitState();
        ChangeState(trackState);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(activeState != null)
        {
            activeState.Perform();
        }
    }

    public void ChangeState(BaseState newState)
    {
        if (activeState != null)
        {
            activeState.Exit();
        }
        activeState = newState;
        if (activeState != null)
        {
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }
}
