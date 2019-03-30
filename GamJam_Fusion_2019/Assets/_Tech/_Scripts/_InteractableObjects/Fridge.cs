using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Fridge : OpenCloseDoors
{
    [SerializeField] private Animator FridgeDoor;
    
    public override void OnOpenDoor() {
        base.OnOpenDoor();
        GameObject tunaClone = Instantiate(transform.GetChild(transform.childCount - 1).gameObject);
        tunaClone.transform.position = transform.GetChild(transform.childCount - 1).position;
        tunaClone.transform.SetParent(transform);
        Debug.Log("Fridge Opened");
        FridgeDoor.SetBool("doorOpened", true);
        
    }

    public override void OnCloseDoor()
    {
        base.OnCloseDoor();
        Debug.Log("Fridge Closed");
        FridgeDoor.SetBool("doorOpened", false);

    }
}
