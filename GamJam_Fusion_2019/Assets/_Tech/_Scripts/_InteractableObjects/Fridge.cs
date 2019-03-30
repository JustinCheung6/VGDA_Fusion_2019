using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    public Interactable interactable;
    private bool isOpen = false;

    private void OnEnable()
    {
        if (interactable == null)
        {
            interactable = GetComponent<Interactable>();
        }
        interactable.OnInteract += handleDoorFridge;
    }

    private void OnDisable()
    {
        interactable.OnInteract -= handleDoorFridge;
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
