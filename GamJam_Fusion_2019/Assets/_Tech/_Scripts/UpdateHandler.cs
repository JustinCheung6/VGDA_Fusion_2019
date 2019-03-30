using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHandler : MonoBehaviour
{
    public delegate void onUpdate();

    public static event onUpdate UpdateOccurred;

    private void FixedUpdate()
    {
        if (UpdateOccurred != null)
            UpdateOccurred();
    }
}
