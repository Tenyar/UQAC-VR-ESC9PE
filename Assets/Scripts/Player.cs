using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public int health;

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }

    public List<string> GetItems()
    {
        List<string> itemNames = new List<string>();
        foreach (Item item in items)
        {
            itemNames.Add(item.GetName());
        }
        return itemNames;
    }

    // Add an item to the notebook (journal)
    public void AddItem(Item newItem)
    {
        items.Add(newItem);
        Debug.Log($"Item {newItem.GetName()} added to player.");
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        GameManager.Instance.PlayerTookDamage(amount);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    private void Die()
    {
        Debug.Log("Player has died.");
        // Add VR-specific death logic here (e.g., fade out, reset scene, etc.)
    }
}