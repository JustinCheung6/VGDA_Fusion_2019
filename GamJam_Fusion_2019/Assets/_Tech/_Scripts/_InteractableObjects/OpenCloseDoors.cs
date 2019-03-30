using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDoors : MonoBehaviour
{
    public Interactable interactable;

    [SerializeField] private string name = "Name";
    private bool isOpen = false;

    private void OnEnable()
    {
        if (interactable == null)
        {
            interactable = GetComponent<Interactable>();
        }
        interactable.OnInteract += HandleDoor;
    }

    private void OnDisable()
    {
        interactable.OnInteract -= HandleDoor;
    }

    private void HandleDoor()
    {
        if (isOpen)
        {
            //Debug.Log("Closed door");
            isOpen = false;

            OnCloseDoor();
        }
        else
        {
            //Debug.Log("Opened door");
            isOpen = true;

            OnOpenDoor();
        }
    }
    public virtual void OnOpenDoor() {

    }

    public virtual void OnCloseDoor() {

    }
}
