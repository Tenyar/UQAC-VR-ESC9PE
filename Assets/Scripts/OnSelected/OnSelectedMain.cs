using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


public class OnSelectedMain : MonoBehaviour
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material highlightMaterial;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;
    private Renderer objectRenderer;
    
    // Virtual method that can be overridden by child classes
    protected virtual void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnSelected);
        objectRenderer = GetComponentInChildren<Renderer>();

        Debug.Log($"XRBaseInteractable {interactable}");

        if (interactable == null)
            Debug.LogError("XRBaseInteractable missing!");
        if (objectRenderer == null)
            Debug.LogError("Renderer missing!");

        objectRenderer = GetComponent<Renderer>();
        // Subscribe to hover events
        interactable.hoverEntered.AddListener(OnHoverEnter);
        interactable.hoverExited.AddListener(OnHoverExit);
    }

    protected virtual void start()
    {

    }

    protected virtual void OnDestroy()
    {
        // Unsubscribe
        if (interactable != null)
        {
            interactable.hoverEntered.RemoveListener(OnHoverEnter);
            interactable.hoverExited.RemoveListener(OnHoverExit);
        }
        interactable.selectEntered.RemoveListener(OnSelected);
    }

    protected virtual void OnHoverEnter(HoverEnterEventArgs args)
    {
        if (objectRenderer != null && highlightMaterial != null)
            objectRenderer.material = highlightMaterial;
    }

    protected virtual void OnHoverExit(HoverExitEventArgs args)
    {
        if (objectRenderer != null && defaultMaterial != null)
            objectRenderer.material = defaultMaterial;
    }

    protected virtual void OnSelected(SelectEnterEventArgs args)
    {
        Debug.Log($"{gameObject.name}: Base YourMethod() triggered");
    }
}