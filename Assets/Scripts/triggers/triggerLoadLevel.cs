using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class triggerLoadLevel : MonoBehaviour
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

            SceneManager.LoadScene(sceneName); // Note: this is a hard reload!
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Nothing for now
    }
}