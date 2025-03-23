using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRPlayerInteraction : MonoBehaviour
{
    public InputActionProperty triggerAction;

    public Transform handTransform;

    
    public float rayDistance = 1.5f;

    void OnEnable()
    {
        triggerAction.action.Enable();
    }

    void OnDisable()
    {
        triggerAction.action.Disable();
    }

    void Update()
    {
        if (triggerAction.action.WasPerformedThisFrame())
        {
            RaycastHit hit;

            Debug.DrawRay(handTransform.position, handTransform.forward * rayDistance, Color.red, 0.1f);

            if (Physics.Raycast(handTransform.position, handTransform.forward, out hit, rayDistance))
            {
                InteractableItem item = hit.collider.GetComponentInParent<InteractableItem>();

                if (item != null)
                {
                    item.registerInteraction();
                }
            }
        }
    }

}
