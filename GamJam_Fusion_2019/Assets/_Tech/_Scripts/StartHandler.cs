using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHandler : MonoBehaviour
{
    public delegate void onStart();

    public static event onStart StartOccurred;

    public void Start()
    {
        if (StartOccurred != null) 
            StartOccurred();
    }
}
