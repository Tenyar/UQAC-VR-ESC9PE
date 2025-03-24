using System;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    // A définir dans l'inspector de unity pour chaque objet dont on veut intéragir avec
    public string itemName;
    public bool isAnomaly;
    private bool isHighlighted = false;


    private Renderer objectRenderer;
    private Color originalColor;

    void Start()
    {
        objectRenderer = GetComponentInChildren<Renderer>();

        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.GetColor("_EmissionColor");
        }
        else
        {
            Debug.LogWarning("No Renderer found for " + gameObject.name);
        }
    }

    public void ToggleHighlight()
    {
        if (objectRenderer == null) return;

        isHighlighted = !isHighlighted;

        if (isHighlighted)
        {
            objectRenderer.material.EnableKeyword("_EMISSION");
            objectRenderer.material.SetColor("_EmissionColor", Color.red * 2f);
        }
        else
        {
            objectRenderer.material.DisableKeyword("_EMISSION");
            objectRenderer.material.SetColor("_EmissionColor", originalColor);
        }
    }

    public void registerInteraction()
    {
        if (!string.IsNullOrEmpty(itemName))
        {
            ToggleHighlight();
            GameManager.Instance.RecordItemInteraction(gameObject, itemName);
        }
    }
}