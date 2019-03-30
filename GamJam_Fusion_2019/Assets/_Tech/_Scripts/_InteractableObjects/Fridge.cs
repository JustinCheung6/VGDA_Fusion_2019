using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    private bool isOpen = false;

    private void OnEnable()
    {
        Interactable.fridgeInteracted += handleDoorFridge;
    }

    private void OnDisable()
    {
        Interactable.fridgeInteracted -= handleDoorFridge;
    }

    private void handleDoorFridge() {
        if (isOpen)
        {
            Debug.Log("Closed fridge door");
            isOpen = false;
        }
        else {
            Debug.Log("Opened fridge door");
            isOpen = true;
        }
    }
}
