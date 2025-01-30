using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInteractable : Interactable
{
    private bool isHeld = false;

    [SerializeField]
    private Transform playerHand;
    private Rigidbody rb;
    private Collider c;
    [SerializeField]
    private Transform parentTransform;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        c = GetComponent<Collider>();
        //parentTransform = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isHeld)
        {
            parentTransform.position = playerHand.position;
            parentTransform.rotation = playerHand.rotation;
        }
    }

    protected override void Interact()
    {
        if (!isHeld)
        {
            parentTransform.position = rb.position;
            parentTransform.rotation = rb.rotation;
            isHeld = true;
            
            rb.isKinematic = true;
            c.enabled = false;
        }
        else
        {
            isHeld = false;
        }
        base.Interact();
    }

    public void Drop()
    {
        isHeld = false;
        rb.isKinematic = false;
        c.enabled = true;
    }
}
