using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{


    // Take Place Object Events
    public delegate void onTakePlaceInteractTuna();
    public static event onTakePlaceInteractTuna takePlaceInteractedTuna;

    // Take Place Object Events
    public delegate void onTakePlaceInteractWasabi();
    public static event onTakePlaceInteractWasabi takePlaceInteractedWasabi;

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
        TakePlaceObjectTuna = 1,
        TakePlaceObjectWasabi = 2,
        OpenCloseDoorFridge = 3,
        OpenCloseDoorCabinet = 4
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
                    Debug.Log("Case 1: Tuna Taken/Placed");
                    if (takePlaceInteractedTuna != null)
                    {
                        takePlaceInteractedTuna();
                    }
                    break;
                case (Interaction) 2:
                    Debug.Log("Case 2: Wasabi Taken/Placed");
                    if (takePlaceInteractedWasabi != null)
                    {
                        takePlaceInteractedWasabi();
                    }
                    break;
                case (Interaction) 3:
                    Debug.Log("Case 2: Fridge Door Opened/Closed");
                    if (fridgeInteracted != null) {
                        fridgeInteracted();
                    }
                    break;
                case (Interaction) 4:
                    Debug.Log("Case 2: Cabinet Door Opened/Closed");
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
