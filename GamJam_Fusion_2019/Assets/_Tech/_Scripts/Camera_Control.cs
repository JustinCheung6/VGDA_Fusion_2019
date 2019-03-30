using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Camera_Control : MonoBehaviour
{
    public enum RotationAxis {
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxis axes = RotationAxis.MouseX;

    //public float minimumVert = -45.0f;
    
    [SerializeField]
    private float minimumVert = -45.0f;
    
    
/*

    public float minimumVert
    {
        get
        {
            return _minimumVert;
        } 
        set
        {
            _minimumVert = minimumVert;
        }
    }*/


    public float maximumVert = 45.0f;

    public float sensHorizontal = 10.0f;
    public float sensVertical = 10.0f;

    public float _rotationX = 0;

    private void OnEnable()
    {
        UpdateHandler.UpdateOccured += CameraInputHandler;
    }

    private void OnDisable()
    {
        UpdateHandler.UpdateOccured -= CameraInputHandler;
    }

    private void CameraInputHandler()
    {
        if (axes == RotationAxis.MouseX) {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0);
        } else if (axes == RotationAxis.MouseY) {
            _rotationX -= Input.GetAxis("Mouse Y") * sensVertical;
            
            // Clamps the vertical angle within the min and max limits (45 degrees)
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX,rotationY,0);
        }
    }
}
