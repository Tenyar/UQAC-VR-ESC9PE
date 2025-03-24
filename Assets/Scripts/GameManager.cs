using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // Current level journal to compare the player choice to
    public List<InteractableItem> currentLevelJournal = new List<InteractableItem>();

    private Player playerData;

    void Awake() {
        Instance = this;
        DontDestroyOnLoad(gameObject); // keep GameManager between levels if he's attached to a gameObject
    }

    private void Start()
    {
        CheckPlayerStatus();
    }

    public GameManager getInstance()
    {
        return this;
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

    public void loadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    // Adds an object to the journal if it is not already in it
    public void RecordItemInteraction(GameObject reference, string itemName)
    {
        // Create an Object "Item"
        InteractableItem itemComponent = reference.GetComponent<InteractableItem>();
        if (itemComponent != null)
        {
            if (this.currentLevelJournal.Contains(itemComponent))
            {
                this.currentLevelJournal.Remove(itemComponent);
                Debug.Log($"[Journal] Objet '{itemName}' supprimé du journal.");
            }
            else
            {
                this.currentLevelJournal.Add(itemComponent);
                Debug.Log($"[Journal] Objet '{itemName}' enregistré dans le journal.");
            }
        }
        else
        {
            Debug.LogWarning($"[Journal] Objet '{itemName}' non trouvé dans la scène !");
        }
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
        // SceneManager.LoadScene("gameover");
    }
}