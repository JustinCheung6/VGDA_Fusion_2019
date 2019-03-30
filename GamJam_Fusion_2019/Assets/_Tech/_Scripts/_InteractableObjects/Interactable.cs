using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Tuna Events
    public delegate void onTakePlaceInteractTuna();
    public static event onTakePlaceInteractTuna takePlaceInteractedTuna;

    // Wasabi Events
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

    // Distance from the center of the object that allows the player to interact with
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

        if (Input.GetButtonDown("LeftClick") ) {
            Debug.Log("Left mouse click");
            if ((distanceBetweenZ < bufferDistance)&&(distanceBetweenX < bufferDistance)) {
                switch (currentInteraction)
                {
                    case (Interaction) 0:
                        Debug.Log("Case 0: Nothing Happened");
                        break;
                    case (Interaction) 1:
                        if (takePlaceInteractedTuna != null)
                        {
                            takePlaceInteractedTuna();
                        }
                        break;
                    case (Interaction) 2:
                        if (takePlaceInteractedWasabi != null)
                        {
                            Debug.Log("WASABIIIIIIIII");
                            //takePlaceInteractedWasabi();
                        }
                        break;
                    case (Interaction) 3:
                        if (fridgeInteracted != null)
                        {
                            fridgeInteracted();
                        }
                        break;
                    case (Interaction) 4:
                        if (cabinetInteracted != null)
                        {
                            cabinetInteracted();
                        }
                        break;
                    default:
                        Debug.Log("Default Case: Nothing Happened");
                        break;
                }
            }
        }
        if (Input.GetButtonDown("RightClick"))
        {
            Debug.Log("Right mouse click");
        }
    }
}
