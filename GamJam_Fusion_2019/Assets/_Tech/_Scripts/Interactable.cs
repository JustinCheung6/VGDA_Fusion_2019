using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject player;
    public GameObject interact;

    public float bufferDistance = 3f;
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
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right mouse click");
        }
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Right mouse click");
        }
    }
}
