using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuna : PickupObject
{

    public override void OnPickedUp()
    {
        base.OnPickedUp();
        Debug.Log("Picked up Tuna!");
    }
    public override void OnDroppedOff()
    {
        base.OnDroppedOff();
        Debug.Log("Dropped up Tuna!");
    }
}