using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    bool isOpen = false;

    private void OnEnable()
    {
        Interactable.cabinetInteracted += handleDoor;
    }

    private void OnDisable()
    {
        Interactable.cabinetInteracted -= handleDoor;
    }

    private void handleDoor() {
        if (isOpen)
        {
            Debug.Log("Close cabinet door");
            isOpen = false;
        }
        else {
            Debug.Log("Open cabinet door");
            isOpen = true;
        }
    }
}
