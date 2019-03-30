using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Interactable : MonoBehaviour
{
    // public delegate void Action();
    public Action OnInteract;

    [SerializeField] private GameObject player;

    // Distance from the center of the object that allows the player to interact with
    [SerializeField] private float bufferDistance = 6f;
    private float distanceBetweenX;
    private float distanceBetweenZ;

    void FixedUpdate()
    {
        distanceBetweenX = Mathf.Abs(player.transform.position.x - transform.position.x);
        distanceBetweenZ = Mathf.Abs(player.transform.position.z - transform.position.z);

        if (Input.GetButtonDown("LeftClick") )
        {
            //Debug.Log("Left mouse click");
            if ((distanceBetweenZ < bufferDistance)&&(distanceBetweenX < bufferDistance)) {

                if(OnInteract != null)
                    OnInteract();
            }
        }
        if (Input.GetButtonDown("RightClick"))
        {
            //Debug.Log("Right mouse click");
        }
    }
}
