using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System.Collections;

public class OnSelectedEscalator : OnSelectedMain
{
    private Color originalColor;
    [SerializeField] private GameObject doors;
    private Animator doorAnimator;
    private bool doorsAreOpen = true;
    [SerializeField] private GameObject tags;

    protected override void Start()
    {
        if (doors != null)
            doorAnimator = doors.GetComponent<Animator>();
        else
            Debug.LogError("Doors GameObject not assigned!");

        if (doorAnimator == null)
            Debug.LogError("Animator not found on doors!");

        // Force sync between bool and Animator at start
        doorAnimator.SetBool("isOpen", doorsAreOpen);
        // Sync local bool to Animator state
        doorsAreOpen = doorAnimator.GetBool("isOpen");
    }

    public override void OnSelected()
    {
        doorsAreOpen = !doorsAreOpen;
        Debug.Log($"{doorsAreOpen }: Closing door now!");
        doorAnimator.SetBool("isOpen", doorsAreOpen);  // Triggers transition in Animator
        
        ////Debug.Log($"{gameObject.name}: Toggling visibility!");

        GameObject  tagOpened = tags.transform.Find("Tags_Opened")?.gameObject;
        GameObject  tagClosed = tags.transform.Find("Tags_Closed")?.gameObject;
        if (tagOpened != null)
            tagOpened.SetActive(!tagOpened.activeSelf);

        if (tagClosed != null)
            tagClosed.SetActive(!tagClosed.activeSelf);

    }
}

