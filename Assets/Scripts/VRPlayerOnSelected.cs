using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VRPlayerOnSelected : MonoBehaviour
{
    public InputActionProperty triggerAction;

    public Transform handTransform;
    
    public float rayDistance = 5f;

    private void OnEnable()
    {
        triggerAction.action.Enable();
    }

    private void OnDisable()
    {
        triggerAction.action.Disable();
    }

    private void Update()
    {
        if (triggerAction.action.WasPerformedThisFrame())
        {
            RaycastHit hit;

            Debug.DrawRay(handTransform.position, handTransform.forward * rayDistance, Color.red, 0.1f);

            if (Physics.Raycast(handTransform.position, handTransform.forward, out hit, rayDistance))
            {
                // Look for a child component of type OnSelectedMain
                OnSelectedMain selectedComponent = hit.transform.GetComponentInChildren<OnSelectedMain>();
                if (selectedComponent != null)
                {
                    selectedComponent.OnSelected();
////                    Debug.Log("Triggered OnSelected on: " + selectedComponent.gameObject.name);
                }
            }
        }
    }
}
