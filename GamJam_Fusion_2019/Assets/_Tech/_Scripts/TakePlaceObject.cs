using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePlaceObject : MonoBehaviour
{
    private bool taken = false;
    private Transform trans;

    [SerializeField] private string name = "Object Name";
    [SerializeField] private float timeTick = 0f;
    [SerializeField] private GameObject player;

    private void OnEnable()
    {
        StartHandler.StartOccurred += getTransform;
        Interactable.takePlaceInteracted += handleObject;
    }

    private void OnDisable()
    {
        StartHandler.StartOccurred -= getTransform;
        Interactable.takePlaceInteracted -= handleObject;
    }

    private void getTransform()
    {
        trans = GetComponent<Transform>();
    }

    private void handleObject() {
        if (taken)
        {
            trans.position = new Vector3(trans.position.x + 1, trans.position.y, trans.position.z + 1);
            Debug.Log("Placed Object");
        }
        else {
            trans.position = player.transform.position;
            Debug.Log("Object Taken");
        }
    }



}
