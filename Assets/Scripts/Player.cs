using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /** Dictionary to record item states: Key = item name/ID, Value = status or state description
     Example of recording an item and its state in the journal
     levelJournal["AncientVase"] = "ItemObject";
     levelJournal["SilverKey"] = "ItemObject";
    **/
    private Dictionary<string, Item> levelJournal = new Dictionary<string, Item>();

    public int health;

    public int GetHealth()
    {
        return this.health;
    }

    public void SetHealth(int newHealth)
    {
        this.health = newHealth;
    }

    public Dictionary<string, Item> GetItems()
    {
        return this.levelJournal;
    }

    // Add an item to the notebook (journal)
    public void AddItem(Item newItem)
    {
        this.levelJournal.Add(newItem.GetName(), newItem);
        Debug.Log($"Item {newItem.GetName()} added to player.");
    }

    public void TakeDamage(int amount)
    {
        int currentHealth = this.health - amount;
        GameManager.Instance.PlayerTookDamage(amount);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        this.health += amount;
        // Limit the life of a player to 100
        this.health = Mathf.Min(this.health, 100);
    }

    private void Die()
    {
        Debug.Log("Player has died.");
        // Add VR-specific death logic here (e.g., fade out, reset scene, etc.)
    }
}