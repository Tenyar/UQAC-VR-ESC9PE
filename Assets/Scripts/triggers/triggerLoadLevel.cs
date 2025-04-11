using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class TriggerLoadLevel : MonoBehaviour
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
            if(GameManager.Instance.getStartTimer() > 0){
                GameManager.Instance.endTimer();
                GameManager.Instance.resetTimers();
            }
            GameManager.Instance.startTimer();
            SceneManager.LoadScene(sceneName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Nothing for now
    }
}