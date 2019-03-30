using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : OpenCloseDoors
{
    public override void OnOpenDoor() {
        base.OnOpenDoor();
        Debug.Log("Fridge Opened");
    }

    public override void OnCloseDoor()
    {
        base.OnCloseDoor();
        Debug.Log("Fridge Closed");
    }
}
