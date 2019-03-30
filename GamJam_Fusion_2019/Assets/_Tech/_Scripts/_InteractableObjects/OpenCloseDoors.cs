using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDoors : MonoBehaviour
{
    public Interactable interactable;
    private bool isOpen = false;

    private void OnEnable()
    {
        if (interactable == null)
        {
            interactable = GetComponent<Interactable>();
        }
        interactable.OnInteractOpenDoor += HandleDoor;
    }

    private void OnDisable()
    {
        interactable.OnInteractOpenDoor -= HandleDoor;
    }

    private void HandleDoor()
    {
        if (isOpen)
        {
            //Debug.Log("Closed door");
            isOpen = false;
            var child = transform.GetChild(transform.childCount - 1);
            if (child.gameObject == GetComponent<Wasabi>() || child.gameObject == GetComponent<Tuna>()) {
                child.gameObject.SetActive(false);
            }
            OnCloseDoor();
        }
        else
        {
            //Debug.Log("Opened door");
            isOpen = true;
            var child = transform.GetChild(transform.childCount - 1);
            if (child.gameObject == GetComponent<Wasabi>() || child.gameObject == GetComponent<Tuna>())
            {
                child.gameObject.SetActive(false);
            }
            OnCloseDoor();

            OnOpenDoor();
        }
    }
    public virtual void OnOpenDoor() {

    }

    public virtual void OnCloseDoor() {

    }
}
