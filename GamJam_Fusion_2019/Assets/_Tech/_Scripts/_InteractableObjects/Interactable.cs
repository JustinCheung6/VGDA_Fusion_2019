using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Fridge Events
    public delegate void onFridgeInteract();
    public static event onFridgeInteract fridgeInteracted;

    // Cabinet Events
    public delegate void onCabinetInteract();
    public static event onCabinetInteract cabinetInteracted;

    [SerializeField] private GameObject player;
    private Transform interactPos;

    // Distance from the center of the object that allows the player to 
    [SerializeField] private float bufferDistance = 6f;
    private float distanceBetweenX;
    private float distanceBetweenZ;

    // Interaction avalible
    public enum Interaction {
        DoNothing = 0,
        TakePlaceObject = 1,
        OpenCloseDoor = 2
    }

    // Assigns interactions to objects
    [SerializeField] private Interaction currentInteraction = 0;


    private void OnEnable()
    {
        StartHandler.StartOccurred += getInteractable;
        UpdateHandler.UpdateOccurred += GetInteraction;
    }

    private void OnDisable()
    {
        StartHandler.StartOccurred -= getInteractable;
        UpdateHandler.UpdateOccurred -= GetInteraction;
    }

    void getInteractable()
    {
        interactPos = GetComponent<Transform>();
    }

    void GetInteraction()
    {
        distanceBetweenX = Mathf.Abs(player.transform.position.x - interactPos.position.x);
        distanceBetweenZ = Mathf.Abs(player.transform.position.z - interactPos.position.z);

        if (Input.GetButtonDown("LeftClick") && distanceBetweenX < bufferDistance && distanceBetweenZ < bufferDistance) {
            Debug.Log("Left mouse click");
            switch (currentInteraction) {
                case (Interaction) 0:
                    Debug.Log("Case 0: Nothing Happened");
                    break;
                case (Interaction) 1:
                    Debug.Log("Case 1: Object Taken/Placed");
                    
                    break;
                case (Interaction) 2:
                    Debug.Log("Case 2: Door Opened/Closed");
                    if (fridgeInteracted != null) {
                        fridgeInteracted();
                    }
                    if (cabinetInteracted != null) {
                        cabinetInteracted();
                    }
                    break;
                default:
                    Debug.Log("Default Case: Nothing Happened");
                    break;
            }
        }
        if (Input.GetButtonDown("RightClick"))
        {
            Debug.Log("Right mouse click");
        }
    }
}
