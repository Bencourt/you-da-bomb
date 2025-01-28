using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    public Transform player;
    public NavMeshAgent Agent { 
        get { return agent; }
        set { agent = value; } }
    public AIPath path;
    public Rigidbody[] ragdollRB;
    public Collider[] ragdollCollider;
    public Animator animator;

    [SerializeField]
    private string currentState;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent= GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        stateMachine.Initialize();

        ragdollRB = GetComponentsInChildren<Rigidbody>();
        ragdollCollider = GetComponentsInChildren<Collider>();

        foreach(Rigidbody rb in ragdollRB)
        {
            rb.isKinematic = true;
        }
        foreach(Collider c in ragdollCollider)
        {
            if (!c.isTrigger)
            {
                c.enabled = false;
            }
        }
    }

    public void GetHit()
    {
        stateMachine.ChangeState(stateMachine.hitState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
