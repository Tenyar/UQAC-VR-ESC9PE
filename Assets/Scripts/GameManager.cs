using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Player playerData;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else
        {
            Destroy(gameObject);
        }

        playerData = new Player(); // Init with default or load
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

        private Boolean CheckPlayerJournalOnTrigger()
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