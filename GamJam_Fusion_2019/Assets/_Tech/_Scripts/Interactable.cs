using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private GameObject interact;

    [SerializeField] private float bufferDistance = 3f;

    public enum Interaction {
        TakeObject = 0,
        PlaceObject = 1
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("LeftClick")) {
            Debug.Log("Left mouse click");
        }
        if (Input.GetButtonDown("RightClick"))
        {
            Debug.Log("Right mouse click");
        }
    }
}
