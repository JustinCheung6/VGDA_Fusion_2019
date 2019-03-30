﻿using System.Collections;
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
            for (int i = 0; i < transform.childCount; i++) {
                var child = transform.GetChild(i).gameObject;
                if (child.GetComponent<PickupObject>()) {
                    child.SetActive(false);
                }
            }
            OnCloseDoor();
        }
        else
        {
            //Debug.Log("Opened door");
            isOpen = true;
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                if (child != null)
                {
                    child.gameObject.SetActive(true);
                }
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