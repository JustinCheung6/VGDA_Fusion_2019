using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasabi : MonoBehaviour
{
    private bool takenWasabi = false;
    private bool inFinalPosWasabi = false;
    private Transform transWasabi;

    [SerializeField] private string name = "Wasabi";
    [SerializeField] private int quantity = 1;
    [SerializeField] private float meterChange = 0f;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject dropOffZone;
    [SerializeField] private float bufferDistance = 6f;

    private float distanceBetweenX;
    private float distanceBetweenZ;

    private void OnEnable()
    {
        StartHandler.StartOccurred += GetWasabi;
        Interactable.takePlaceInteractedWasabi += HandleWasabi;
        UpdateHandler.UpdateOccurred += MoveWasabi;
    }

    private void OnDisable()
    {
        StartHandler.StartOccurred -= GetWasabi;
        Interactable.takePlaceInteractedWasabi -= HandleWasabi;
        UpdateHandler.UpdateOccurred -= MoveWasabi;
    }

    private void GetWasabi()
    {
        transWasabi = GetComponent<Transform>();
    }

    private void HandleWasabi()
    {
        if (takenWasabi)
        {
            if ((distanceBetweenX < bufferDistance) && (distanceBetweenZ < bufferDistance))
            {
                Debug.Log("Wasabi Placed");
                float offset = (float)dropOffZone.transform.position.y + 0.5f;
                transWasabi.position = new Vector3(dropOffZone.transform.position.x, offset, dropOffZone.transform.position.z);
                takenWasabi = false;
                inFinalPosWasabi = true;
            }
        }
        else if (!takenWasabi && !inFinalPosWasabi)
        {
            Debug.Log("Wasabi Taken");
            takenWasabi = true;
        }
    }

    private void MoveWasabi()
    {
        distanceBetweenX = Mathf.Abs(player.transform.position.x - dropOffZone.transform.position.x);
        distanceBetweenZ = Mathf.Abs(player.transform.position.z - dropOffZone.transform.position.z);
        if (takenWasabi)
        {
            transWasabi.position = player.transform.position;
        }
    }
}
