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
    private String checkPoint;
    private float stageStartTime = 0;
    private float stageEndTime = 0;

    void Awake() {
        // If another instance already exists and it's not this one, destroy this
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("[GameManager] Duplicate found, destroying the new one.");
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        // Check before the game the first frame if the player is present in the scene
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        if (playerGO == null)
            {
                Debug.LogError("[GameManager] Could not find GameObject with tag 'Player'");
                return;
            }

        playerData = playerGO.GetComponent<Player>();
        if (playerData == null)
            {
                Debug.LogError("[GameManager] Found GameObject, but it has no Player script!");
                return;
            }

        initPlayerStatus();
    }

    public String getCheckPoint()
    {
        return this.checkPoint;
    }

    public float getStartTimer()
    {
        return this.stageStartTime;
    }

    
    public void setCheckPoint(String newCheckPoint)
    {
        this.checkPoint = newCheckPoint;
    }

    public void resetTimers(){
        stageStartTime = 0;
        stageEndTime = 0;
    }
  
    public void playerTookDamage(int amount)
    {
        playerData.setHealth(playerData.getHealth() - amount);
        Debug.Log($"Player Health: {playerData.health}");

        if (playerData.health <= 0)
        {
            HandleGameOver();
        }
    }

    private void initPlayerStatus()
    {
        // Player have 3 lives (hearts) at the start
        this.playerData.setHealth(3);
    }

    public bool checkPlayer()
    {
        // if the player have a journal and noted more at least 1 item
        if (this.playerData.getPlayerJournal() != null && this.playerData.getPlayerJournal().Count > 0)
        {
            // loop through the level list to see if the player got all the anomalies
            foreach (InteractableItem item in this.playerData.getPlayerJournal()){
                if(item.getAnomaly() == false){
                    return false;
                }
            }
            return true;
        }else {
            return false;
        }
    }
    
    // When the gameObject containing the script is enabled
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(DelayBindPlayer());
    }

    private IEnumerator DelayBindPlayer()
    {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");

        if (playerGO == null)
        {
            Debug.LogWarning("[GameManager] Player GameObject not found after scene load.");
            yield break;
        }

        Player newPlayer = playerGO.GetComponent<Player>();
        if (newPlayer == null)
        {
            Debug.LogWarning("[GameManager] Player script not found on GameObject.");
            yield break;
        }

        // Transfer data from previous player gameObject script if needed(meaning we loaded a new level)
        if (playerData != null)
        {
            newPlayer.setHealth(playerData.getHealth());
            newPlayer.getPlayerJournal().Clear();
            newPlayer.getPlayerJournal().AddRange(playerData.getPlayerJournal());
        }

        playerData = newPlayer;
        Debug.Log("[GameManager] Player successfully re-linked after scene load.");
    }

    public void startTimer()
    {
        stageStartTime = Time.time;
        Debug.Log($"[Timer] Stage started at: {stageStartTime}");
    }

    public void endTimer()
    {
        stageEndTime = Time.time;

        float elapsed = stageEndTime - stageStartTime;
        Debug.Log($"[Timer] Stage ended at: {stageEndTime}");
        Debug.Log($"[Timer] Stage duration: {elapsed:F2} seconds");
    }
   
    public void finishLevel(string sceneName)
    {
        if(this.checkPlayer()){ // if true
            this.setCheckPoint(sceneName);
            Debug.Log("----------- [PLAYER FINISHED !] -----------");
            SceneManager.LoadScene(sceneName);
        } else {
            Debug.Log("----------- [PLAYER GAME OVER !] -----------");
            SceneManager.LoadScene(sceneName);
        }
    }

    public IEnumerator teleportPlayerLocRot(Transform teleportDestination)
    {
        yield return new WaitForSeconds(2f); // wait for 2 seconds

        GameObject xrOrigin = GameObject.FindGameObjectWithTag("Anchor");

        if (xrOrigin != null && teleportDestination != null)
        {
            xrOrigin.transform.position = teleportDestination.position;
            xrOrigin.transform.rotation = teleportDestination.rotation;
            Debug.Log("XR Origin teleported!");
        }
        else
        {
            Debug.LogError("XR Origin or Teleport Destination not assigned!");
        }
    }

    // Adds an object to the journal if it is not already in it
    public void recordItemInteraction(GameObject reference, string itemName)
    {
        // Create an Object "Item"
        InteractableItem itemComponent = reference.GetComponent<InteractableItem>();
        if (itemComponent != null)
        {
            if (this.currentLevelJournal.Contains(itemComponent))
            {
                this.playerData.getPlayerJournal().Remove(itemComponent);
                Debug.Log($"[Journal] Objet '{itemName}' supprimé du journal.");
                Debug.Log($"PLAYER JOURNAL '{this.playerData.getPlayerJournal()}'");
            }
            else
            {
                this.playerData.getPlayerJournal().Add(itemComponent);
                Debug.Log($"[Journal] Objet '{itemName}' enregistré dans le journal.");
                Debug.Log($"PLAYER JOURNAL '{this.playerData.getPlayerJournal()}'");
            }
        }
        else
        {
            Debug.LogWarning($"[Journal] Objet '{itemName}' non trouvé dans la scène !");
        }
    }

    // Return the player to the lobby
    private void HandleGameOver()
    {
        Debug.Log("Game Over!");
        //TODO : Add VR-specific death logic here (e.g., fade out, reset scene, etc.)
        // TODO : Show GameOver UI, reset level, etc.
        SceneManager.LoadScene("Lobby");
    }
}