using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuna : MonoBehaviour
{
    private bool taken = false;
    private bool inFinalPos = false;
    private Transform trans;

    [SerializeField] private string name = "Tuna";
    [SerializeField] private int quantity = 1;
    [SerializeField] private float meterChange = 0f;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject dropOffZone;
    [SerializeField] private float bufferDistance = 6f;

    private float distanceBetweenX;
    private float distanceBetweenZ;

    private void OnEnable()
    {
        StartHandler.StartOccurred += GetTransform;
        Interactable.takePlaceInteractedTuna += HandleObject;
        UpdateHandler.UpdateOccurred += MoveObject;
    }

    private void OnDisable()
    {
        StartHandler.StartOccurred -= GetTransform;
        Interactable.takePlaceInteractedTuna -= HandleObject;
        UpdateHandler.UpdateOccurred -= MoveObject;
    }

    private void GetTransform()
    {
        trans = GetComponent<Transform>();
    }

    private void HandleObject() {
        if (taken)
        {
            if (distanceBetweenX < bufferDistance && distanceBetweenZ < bufferDistance) {
                Debug.Log("Object Placed");
                float offset = (float)dropOffZone.transform.position.y + 0.5f;
                trans.position = new Vector3(dropOffZone.transform.position.x, offset, dropOffZone.transform.position.z);
                taken = false;
                inFinalPos = true;
            }
        }
        else if(!taken && !inFinalPos){
            Debug.Log("Object Taken");
            taken = true;
        }
    }

    private void MoveObject() {
        distanceBetweenX = Mathf.Abs(player.transform.position.x - dropOffZone.transform.position.x);
        distanceBetweenZ = Mathf.Abs(player.transform.position.z - dropOffZone.transform.position.z);
        if (taken)
        {
            trans.position = player.transform.position;
        }
    }
}
