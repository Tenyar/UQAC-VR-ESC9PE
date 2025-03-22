using UnityEngine;
using UnityEngine.InputSystem;

public class VRPlayerInteraction : MonoBehaviour
{
    // Référence à l'action de la gâchette (trigger) via le système Input System
    public InputActionProperty triggerAction;

    // Position de la main du joueur (où l’objet est tenu)
    public Transform handTransform;

    private void Update()
    {
        // Vérifie si la gâchette vient d’être pressée à la frame en cours
        if (triggerAction.action.WasPerformedThisFrame())
        {
            RaycastHit hit;

            // On lance un rayon très court à partir de la main vers l’avant
            if (Physics.Raycast(handTransform.position, handTransform.forward, out hit, 0.2f))
            {
                // Vérifie si l’objet touché a un script "InteractableItem"
                InteractableItem item = hit.collider.GetComponent<InteractableItem>();
                if (item != null)
                {
                    // Si oui, on enregistre son interaction dans le journal
                    item.registerInteraction();
                }
            }
        }
    }
}
