using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class PickupObject : InteractableSubscriber
{
    private bool takenObject = false;
    private bool inFinalPos = false;

    public Ticker ticktock;
    public Score playerScore;

    [SerializeField] private string name = "NAME";
    [SerializeField] private float meterChange = 0f;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject dropOffZone;
    [SerializeField] private float bufferDistance = 6f;

    public UnityEvent OnDropOff;

    protected override void HandleInteract()
    {
        if (!takenObject && !inFinalPos)
        {
            if (inventory.transform.childCount == 0)
            {
                DoPickUp();
            }
            else {
                Debug.Log("Already holding something");
            }
        }
    }
    public void TryDropOff()
    {
        if (takenObject)
        {
            DoDropOff();
        }
    }

    private void DoPickUp()
    {
        Debug.Log("Object Taken");
        takenObject = true;

        inventory.GetComponent<InventoryManager>().AddPickup(this);

        Debug.Log("Object Taken FOR SURE");
        OnPickedUp();
    }

    private void DoDropOff()
    {
        float dropOffDistanceBetweenX = Mathf.Abs(player.transform.position.x - dropOffZone.transform.position.x);
        float dropOffDistanceBetweenZ = Mathf.Abs(player.transform.position.z - dropOffZone.transform.position.z);
        Debug.Log("X Distance: " + dropOffDistanceBetweenX);
        Debug.Log("Z Distance: " + dropOffDistanceBetweenZ);
        if ((dropOffDistanceBetweenX < bufferDistance) && (dropOffDistanceBetweenZ < bufferDistance))
        {
            Debug.Log("Object Placed");
            float offset = (float)dropOffZone.transform.position.y + 0.5f;
            transform.position = new Vector3(dropOffZone.transform.position.x, offset, dropOffZone.transform.position.z);
            takenObject = false;
            inFinalPos = true;
            this.transform.SetParent(null);


            // Random chance to get an increased or decreased meter
            int random = UnityEngine.Random.Range(0,10);
            if (random <5)
                ticktock.incrementTicker(meterChange);
            else
                ticktock.decrementTicker(meterChange);

            playerScore.playerScored(100);

            inventory.GetComponent<InventoryManager>().DropPickup();
            OnDroppedOff();
        }
    }

    public virtual void OnPickedUp()
    {
    }
    public virtual void OnDroppedOff()
    {
        OnDropOff.Invoke();
    }
}
