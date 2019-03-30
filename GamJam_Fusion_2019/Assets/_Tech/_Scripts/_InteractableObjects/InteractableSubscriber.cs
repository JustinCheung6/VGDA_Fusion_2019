using UnityEngine;
using System.Collections;

public abstract class InteractableSubscriber : MonoBehaviour
{
    public Interactable interactable;

    private void OnEnable()
    {
        if (interactable == null)
        {
            interactable = GetComponent<Interactable>();
        }
        interactable.OnInteract += HandleInteract;
    }

    private void OnDisable()
    {
        interactable.OnInteract -= HandleInteract;
    }

    protected abstract void HandleInteract();
}
