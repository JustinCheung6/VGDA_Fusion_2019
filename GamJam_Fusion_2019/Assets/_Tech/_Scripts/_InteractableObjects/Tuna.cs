using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuna : MonoBehaviour
{
    private bool takenTuna = false;
    private bool inFinalPosTuna = false;
    private Transform transTuna;

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
        StartHandler.StartOccurred += GetTuna;
        Interactable.takePlaceInteractedTuna += HandleTuna;
        UpdateHandler.UpdateOccurred += MoveTuna;
    }

    private void OnDisable()
    {
        StartHandler.StartOccurred -= GetTuna;
        Interactable.takePlaceInteractedTuna -= HandleTuna;
        UpdateHandler.UpdateOccurred -= MoveTuna;
    }

    private void GetTuna()
    {
        transTuna = GetComponent<Transform>();
    }

    private void HandleTuna() {
        if (takenTuna)
        {
            if (distanceBetweenX < bufferDistance && distanceBetweenZ < bufferDistance) {
                Debug.Log("Tuna Placed");
                float offset = (float)dropOffZone.transform.position.y + 0.5f;
                transTuna.position = new Vector3(dropOffZone.transform.position.x, offset, dropOffZone.transform.position.z);
                takenTuna = false;
                inFinalPosTuna = true;
            }
        }
        else if(!takenTuna && !inFinalPosTuna){
            Debug.Log("Tuna Taken");
            takenTuna = true;
        }
    }

    private void MoveTuna() {
        distanceBetweenX = Mathf.Abs(player.transform.position.x - dropOffZone.transform.position.x);
        distanceBetweenZ = Mathf.Abs(player.transform.position.z - dropOffZone.transform.position.z);
        if (takenTuna)
        {
            transTuna.position = player.transform.position;
        }
    }
}
