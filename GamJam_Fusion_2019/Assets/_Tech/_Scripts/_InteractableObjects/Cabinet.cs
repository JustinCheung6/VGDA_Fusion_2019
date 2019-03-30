using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    private bool isOpen = false;

    private void OnEnable()
    {
        Interactable.cabinetInteracted += handleDoorCab;
    }

    private void OnDisable()
    {
        Interactable.cabinetInteracted -= handleDoorCab;
    }

    private void handleDoorCab() {
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
