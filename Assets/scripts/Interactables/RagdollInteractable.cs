using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RagdollInteractable : Interactable
{
    private bool isHeld = false;

    [SerializeField]
    private Transform playerHand;
    [SerializeField]
    private Rigidbody spineRB;
    private Rigidbody[] rigidbodies;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isHeld)
        {
            gameObject.transform.position = playerHand.position;
            gameObject.transform.rotation = playerHand.rotation;
            spineRB.MovePosition(gameObject.transform.position);
        }
    }

    protected override void Interact()
    {
        if (!isHeld)
        {
            isHeld = true;
            foreach(Rigidbody r in rigidbodies)
            {
                r.isKinematic = false;
            }
            spineRB.isKinematic = true;
            //spineRB.transform.position = playerHand.position;
        }
        else
        {
            isHeld = false;
        }
        base.Interact();
    }
}
