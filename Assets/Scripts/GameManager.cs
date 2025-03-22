using System;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // Current level journal to compare the player choice to
    public Dictionary<string, Item> currentLevelJournal = new Dictionary<string, Item>();

    private Player playerData;

    void Awake() {
        Instance = this;
        DontDestroyOnLoad(gameObject); // keep GameManager between levels if he's attached to a gameObject
    }

    private void Start()
    {
        CheckPlayerStatus();
    }

    public void UpdatePlayerProgress(string checkpoint)
    {
        // Level checkpoint
        ////playerData.lastCheckpoint = checkpoint;
        Debug.Log($"Player reached: {checkpoint}");

        // Trigger actions based on checkpoint
        if (checkpoint == "Level_1")
        {
            ////SpawnEnemies();
        }
    }

    // Adds an object to the journal if it is not already in it
    public void RecordItemInteraction(GameObject reference, string itemName)
    {
        // Create an Object "Item"
        Item itemComponent = reference.GetComponent<Item>();
        if (itemComponent != null && !this.currentLevelJournal.ContainsKey(itemName))
        {
            // Store --> {"itemName" = ObjetItem}
            this.currentLevelJournal[itemName] = itemComponent;
            Debug.Log($"[Journal] Objet '{itemName}' enregistré dans le journal.");
        }
        else
        {
            Debug.LogWarning($"[Journal] Objet '{itemName}' non trouvé dans la scène !");
        }
    }
    
    public void PlayerTookDamage(int amount)
    {
        playerData.health -= amount;
        Debug.Log($"Player Health: {playerData.health}");

        if (playerData.health <= 0)
        {
            HandleGameOver();
        }
    }

    private void CheckPlayerStatus()
    {
        // TODO : Implement some game logic here
    }

        private bool CheckPlayerJournalOnTrigger()
    {
        // TODO : Check for player's dictionnary with current level anomalies.
        /*
        if (playerData.getJournal() != null && playerData.getJournal().Count > 0)
        {
            ValidateLevel();
        }
        */
        return true;
    }

    private void SpawnEnemies()
    {
        Debug.Log("Spawning enemies...");
        //! Call enemy manager ?, instantiate prefabs, etc.
    }

    private void ValidateLevel()
    {
        Debug.Log("Level passed !");
        // TODO : Implement next level logic.
    }

    private void HandleGameOver()
    {
        Debug.Log("Game Over!");
        // TODO : Show GameOver UI, reset level, etc.
    }
}