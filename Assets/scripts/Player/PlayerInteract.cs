using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private LayerMask enemyMask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private Transform hand;
    [SerializeField]
    private Transform handEnd;
    private Transform handStart;
    [SerializeField]
    private float attackSpeed = .25f;
    private float start = .33f;
    private float end = -0.64f;
    private bool attacking = false;
    private bool attackLerp = false;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI= GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
        handStart = hand.transform;
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null) {
                Interactable interactable  = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if(inputManager.onFoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
        if (Physics.Raycast(ray, out hitInfo, distance, enemyMask))
        {
            if (hitInfo.collider.GetComponent<Enemy>() != null)
            {
                
            }
        }

        if (inputManager.onFoot.Attack.triggered)
        {
            if (!attacking)
            {
                playerAnimator.SetBool("IsAttacking", true);
                Debug.Log("Attacked");
                attacking = true;
                attackLerp = true;
                attackSpeed = 0f;
            }
        }
        if (attacking)
        {
            attackSpeed += Time.deltaTime;
            float p = attackSpeed / 1f;
            if (attackLerp)
            {
                //hand.position.Set(Mathf.Lerp(handStart.position.x, handEnd.position.x, p * 2), hand.position.y, hand.position.z);
                //hand.SetLocalPositionAndRotation(new Vector3(Mathf.Lerp(start, end, p * 2), hand.localPosition.y, hand.localPosition.z), hand.localRotation);
                Debug.Log("hand x position: " + hand.position.x);
            }
            else
            {
                //hand.position.Set(Mathf.Lerp(handEnd.position.x, handStart.position.x, (p - .5f) * 2), hand.position.y, hand.position.z);
                //hand.Translate(Mathf.Lerp(end, start, (p - .5f) * 2), 0, 0);
                //hand.SetLocalPositionAndRotation(new Vector3(Mathf.Lerp(end, start, (p - .25f) * 2), hand.localPosition.y, hand.localPosition.z), hand.localRotation);
                Debug.Log("hand x position: " + hand.position.x);
            }

            if (p > .5)
            {
                Debug.Log("Max Hand Position");
                attackLerp = false;
            }
            if (p > .1)
            {
                attackSpeed = 0f;
                attacking = false;
                playerAnimator.SetBool("IsAttacking", false);
            }
        }
    }
}
