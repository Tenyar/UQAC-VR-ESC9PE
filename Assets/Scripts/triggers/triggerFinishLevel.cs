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
            // Check player Data Anoamly if the level contains anomaly
            GameManager.Instance.finishLevel(sceneName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Nothing for now
    }
}