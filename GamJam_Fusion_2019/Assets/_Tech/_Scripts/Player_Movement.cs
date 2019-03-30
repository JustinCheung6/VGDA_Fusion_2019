using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float gravity = -9.8f;


    private CharacterController _charCont;



    private void OnEnable()
    {
        StartHandler.StartOccurred += GetCharacterControllerComponent;
        UpdateHandler.UpdateOccurred += ControlPlayerMovement;
    }

    private void OnDisable()
    {
        StartHandler.StartOccurred -= GetCharacterControllerComponent;
        UpdateHandler.UpdateOccurred -= ControlPlayerMovement;
    }

    void GetCharacterControllerComponent()
    {
        _charCont = GetComponent<CharacterController>();

    }

    void ControlPlayerMovement()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        // Limits movement speed 
        movement = Vector3.ClampMagnitude(movement, speed);

        movement.y = gravity;

        // Updates movement per frame based on time passed
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charCont.Move(movement);
    }
}
