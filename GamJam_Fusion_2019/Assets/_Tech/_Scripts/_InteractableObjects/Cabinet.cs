using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    public Interactable interactable;
    private bool isOpen = false;

    private void OnEnable()
    {
        if (interactable == null)
        {
            interactable = GetComponent<Interactable>();
        }
        interactable.OnInteract += handleDoorCab;
    }

    private void OnDisable()
    {
        interactable.OnInteract -= handleDoorCab;
    }

    private void handleDoorCab() {
        if (isOpen)
        {
            Debug.Log("Closed cabinet door");
            isOpen = false;
        }
        else {
            Debug.Log("Opened cabinet door");
            isOpen = true;
        }
    }
}
