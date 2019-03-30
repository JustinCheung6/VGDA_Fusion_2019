using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // Walking speed
    [SerializeField] private float speed = 6.0f;

    // Gravity -- effects vertical movement
    [SerializeField] private float gravity = -9.8f;

    // Character controller 
    private CharacterController _charCont;

    private void OnEnable()
    {
        StartHandler.StartOccurred += SetUpFPS;
        UpdateHandler.UpdateOccurred += ControlPlayerMovement;
    }

    private void OnDisable()
    {
        StartHandler.StartOccurred -= SetUpFPS;
        UpdateHandler.UpdateOccurred -= ControlPlayerMovement;
    }

    void SetUpFPS()
    {
        _charCont = GetComponent<CharacterController>();
        Cursor.visible = false;

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
