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

    protected virtual void Start()
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

    public virtual void OnSelected()
    {
        Debug.Log($"{gameObject.name}: Base YourMethod() triggered");
    }
}