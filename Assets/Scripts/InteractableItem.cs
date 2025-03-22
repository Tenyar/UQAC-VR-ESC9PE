using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    // A définir dans l'inspector de unity pour chaque objet dont on veut intéragir avec
    public string itemName;

    public void registerInteraction()
    {
        if (!string.IsNullOrEmpty(itemName))
        {
            GameManager.Instance.RecordItemInteraction(gameObject, itemName);
        }
    }
}