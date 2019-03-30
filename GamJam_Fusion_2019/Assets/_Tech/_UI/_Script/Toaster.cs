using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster : MonoBehaviour
{
    private Animator animt;

    // Start is called before the first frame update
    void Start()
    {
        animt = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animt.GetCurrentAnimatorStateInfo(0).IsName("Oven Mehigy")){
            Destroy(gameObject);
        }
    }
}
