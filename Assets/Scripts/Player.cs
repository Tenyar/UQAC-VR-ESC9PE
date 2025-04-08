using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    // Player's journal to compare his choices with the gameManager at the end of each level
    public List<InteractableItem> playerJournal = new List<InteractableItem>();
    public Transform xrOrigin; // Drag your XR Origin GameObject here
    private Vector3 offset;


    void Start()
    {
        // Calculate the initial offset once
        offset = transform.position - xrOrigin.position;
    }

    void LateUpdate() // Late to wait the XR origin to finish updating the new coordinates.
    {
        // Update only position; ignore XR Origin rotation
        transform.position = xrOrigin.position + offset;
    }

    public int getHealth()
    {
        return this.health;
    }

    public void setHealth(int newHealth)
    {
        this.health = newHealth;
    }

    public void addHealth(int amount)
    {
        this.health += amount;
        // Limit the life of a player to 3
        this.health = Mathf.Min(this.health, 3);
    }

    public List<InteractableItem> getPlayerJournal(){
        return this.playerJournal;
    }

    public void takeDamage(int amount)
    {
        GameManager.Instance.playerTookDamage(amount);
    }
}