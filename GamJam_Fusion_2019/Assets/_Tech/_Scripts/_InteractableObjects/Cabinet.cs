using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : OpenCloseDoors
{
    [SerializeField]
    private Animator leftDoor;
    [SerializeField]
    private Animator rightDoor;
    
    public override void OnOpenDoor()
    {
        base.OnOpenDoor();
        Debug.Log("Cabinet Opened");
        leftDoor.SetBool("doorOpened", true);
        rightDoor.SetBool("doorOpened", true);
    }

    public override void OnCloseDoor()
    {
        base.OnCloseDoor();
        Debug.Log("Cabinet Closed");
        leftDoor.SetBool("doorOpened", false);
        rightDoor.SetBool("doorOpened", false);
    }
}
