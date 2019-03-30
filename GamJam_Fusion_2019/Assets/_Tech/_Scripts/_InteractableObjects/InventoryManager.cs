using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour
{
    public PickupObject obj;

    public string InputButtonName = "LeftClick";

    public void AddPickup(PickupObject pickup)
    {
        obj = pickup;
        pickup.transform.SetParent(this.transform);
        pickup.transform.localPosition = Vector3.zero;
    }

    public void DropPickup()
    {
        if(obj != null)
        {
            // Position setting and unparenting handled in PickupObject
            obj = null;
        }
    }

    void Update()
    {
        if(Input.GetButtonDown(InputButtonName))
        {
            if (obj != null)
            {
                obj.TryDropOff();
            }
        }
    }
}
