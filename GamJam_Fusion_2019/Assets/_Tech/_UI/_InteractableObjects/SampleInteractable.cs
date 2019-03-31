using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleInteractable : InteractableSubscriber
{
    protected override void HandleInteract()
    {
        Debug.Log("INTERACTED WITH!");

        this.transform.localScale = this.transform.localScale * 0.75f;
    }
}
