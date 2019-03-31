using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasabi : PickupObject
{
    public override void OnPickedUp()
    {
        base.OnPickedUp();
        Debug.Log("Picked up Wasabi!");
    }
    public override void OnDroppedOff()
    {
        base.OnDroppedOff();
        Debug.Log("Dropped up Wasabi!");
    }
}
