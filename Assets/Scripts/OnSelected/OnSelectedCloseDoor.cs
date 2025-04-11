using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class OnSelectedCloseDoor : OnSelectedMain
{
    private Color originalColor;
    [SerializeField] private GameObject tagClosed;
    [SerializeField] private GameObject tagOpened;
    protected override void OnSelected(SelectEnterEventArgs args)
    {
        Debug.Log($"{gameObject.name}: Closing door now!");
        Debug.Log($"{gameObject.name}: Toggling visibility!");
        if (tagOpened != null)
            tagOpened.SetActive(!tagOpened.activeSelf);

        if (tagClosed != null)
            tagClosed.SetActive(!tagClosed.activeSelf);
    }
}