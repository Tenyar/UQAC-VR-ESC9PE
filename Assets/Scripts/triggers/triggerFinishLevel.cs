using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class triggerFinishLevel : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
                if (other.CompareTag("Player"))
        {
            if (GameManager.Instance == null)
            {
                Debug.LogError("[triggerLoadLevel] GameManager.Instance is NULL!");
            }
            else
            {
                Debug.Log($"[triggerLoadLevel] Found GameManager: {GameManager.Instance}");
                GameManager.Instance.setCheckPoint(sceneName);
            }

            GameObject xrSimulator = GameObject.Find("Player_Simulator");
            if (xrSimulator != null)
            {
                Destroy(xrSimulator);
                Debug.Log("[ XR DEVICE SIMULATOR ] ------ DESTROYED !!");
            }
            // Check player Data Anoamly if the level contains anomaly
            GameManager.Instance.endTimer();
            GameManager.Instance.resetTimers();
            GameManager.Instance.finishLevel(sceneName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Nothing for now
    }
}