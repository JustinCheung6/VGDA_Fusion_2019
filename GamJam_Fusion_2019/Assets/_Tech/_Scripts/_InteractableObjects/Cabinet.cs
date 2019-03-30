﻿using System.Collections;
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
        GameObject wasabiClone = Instantiate(transform.GetChild(transform.childCount - 1).gameObject);
        wasabiClone.transform.position = transform.GetChild(transform.childCount - 1).position;
        wasabiClone.transform.SetParent(transform);
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
