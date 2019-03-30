using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenCloseDoors : MonoBehaviour
{
    public Interactable interactable;
    private bool isOpen = false;

    public UnityEvent OnOpenDoorEvent;
    public UnityEvent OnCloseDoorEvent;

    private void Awake()
    {
        interactable.InputButtonName = "RightClick";
    }
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
    public virtual void OnOpenDoor()
    {
        //var child = transform.GetChild(transform.childCount - 1);
        //if (child.gameObject == GetComponent<Wasabi>() || child.gameObject == GetComponent<Tuna>())
        //{
        //    child.gameObject.SetActive(false);
        //}
        OnOpenDoorEvent.Invoke();
    }

    public virtual void OnCloseDoor()
    {
        //var child = transform.GetChild(transform.childCount - 1);
        //if (child.gameObject == GetComponent<Wasabi>() || child.gameObject == GetComponent<Tuna>())
        //{
        //    child.gameObject.SetActive(false);
        //}
        OnCloseDoorEvent.Invoke();
    }
}
