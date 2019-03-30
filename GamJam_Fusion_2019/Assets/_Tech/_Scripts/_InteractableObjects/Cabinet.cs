using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : OpenCloseDoors
{
    public override void OnOpenDoor()
    {
        base.OnOpenDoor();
        Debug.Log("Cabinet Opened");
    }

    public override void OnCloseDoor()
    {
        base.OnCloseDoor();
        Debug.Log("Cabinet Closed");
    }
}
