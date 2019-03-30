using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Fridge : OpenCloseDoors
{
    [SerializeField] private Animator FridgeDoor;

    public GameObject pickupPrefab;
    public Transform content;

    public void Start()
    {
        
    }

    public override void OnOpenDoor()
    {
        base.OnOpenDoor();
        SpawnNewItem();
        Debug.Log("Fridge Opened");
        FridgeDoor.SetBool("doorOpened", true);
        content.gameObject.SetActive(true);
    }

    public override void OnCloseDoor()
    {
        base.OnCloseDoor();
        Debug.Log("Fridge Closed");
        FridgeDoor.SetBool("doorOpened", false);
        content.gameObject.SetActive(false);
    }
    private void SpawnNewItem()
    {
        GameObject tunaClone = GameObject.Instantiate(pickupPrefab);
        tunaClone.transform.position = content.position;
        tunaClone.transform.SetParent(content);
        tunaClone.SetActive(true);
    }
}
