using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePlaceObject : MonoBehaviour
{
    private bool taken = false;

    [SerializeField] private string name = "Object Name";
    [SerializeField] private float timeTick = 0f;
    //[SerializeField] priate GameObject player;

    // Objects avalible
    public enum Objects {
        Nothing = 0,
        Tuna = 1,
        Wasabi = 2
    }
    [SerializeField] private Objects currentObject = 0;

    private void OnEnable()
    {
        Interactable.takePlaceInteracted += handleObject;
    }

    private void OnDisable()
    {
        Interactable.takePlaceInteracted -= handleObject;
    }

    private void handleObject() {
        if (taken)
        {
            Debug.Log("Placed Object");
        }
        else {
            Debug.Log("Object Taken");
        }
    }
}
