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
            Debug.Log("Closed cabinet door");
            isOpen = false;
        }
        else {
            Debug.Log("Opened cabinet door");
            isOpen = true;
        }
    }
}
