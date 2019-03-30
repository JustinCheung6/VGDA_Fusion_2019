using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    private bool isOpen = false;

    private void OnEnable()
    {
        Interactable.fridgeInteracted += handleDoor;
    }

    private void OnDisable()
    {
        Interactable.fridgeInteracted -= handleDoor;
    }

    private void handleDoor() {
        if (isOpen)
        {
            Debug.Log("Close fridge door");
            isOpen = false;
        }
        else {
            Debug.Log("Open fridge door");
            isOpen = true;
        }
    }
}
