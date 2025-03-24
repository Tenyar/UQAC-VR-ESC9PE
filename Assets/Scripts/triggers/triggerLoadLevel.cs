using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class triggerLoadLevel : MonoBehaviour
{
    public string sceneName;
    private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        print("TESTTTT");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone!");
            // Put your logic here (e.g., load scene, open door)
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger zone!");
        }
    }
}