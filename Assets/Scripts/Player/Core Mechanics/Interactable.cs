using UnityEngine;

public class Interactable : MonoBehaviour
{

    /* 
     * Creates base class for all interactions with elements in the game
     * This will be extended into other scripts and will never need to be
     * added to an item manually.
     * 
     * Heavily influenced and borrowed from Brackys tutorials
     */

    private Transform interactor;
    private Transform interactionTransform;

    [SerializeField]
    private bool isObjectInteractable = true; // Debugging option
    [SerializeField]
    private float interactableRadius = 1f; // Distance from item before it is interactable

    private bool interactionHasStarted = false;
    private bool objectIsTheFocus = false;


    public virtual void Interact()
    {
        // This is meant to be extended or overwritten 

        if (isObjectInteractable)
            interactionHasStarted = true;

        // Show debugging UI
        OnDrawGizmosSelected();

        // Display a UI indicator such as an outline?
        // Destroy
    }

    // Main interaction gate keeper 
    public void IfCanInteract()
    {
        if (objectIsTheFocus && !interactionHasStarted)
        {
            float distance = Vector3.Distance(interactor.position, interactionTransform.position);

            if (distance <= interactableRadius)
            {
                Interact(); // Override allows this to be different per item
                interactionHasStarted = true;
            }
        }
    }

    private void OnFocused(Transform interactorTransform)
    {
        objectIsTheFocus = true; // When the player has focused on this item set this to True
        interactor = interactorTransform; // Get distance of currently interacting actor
        interactionHasStarted = false; // It hasn't yet, but, it could now 
    }

    // Called to remove focus from last selected item
    private void OnDefocused()
    {
        objectIsTheFocus = false;
        interactor = null;
        interactionHasStarted = false;
    }

    // Debugging tool to show interaction distance in editor
    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, interactableRadius);
    }

    void Update()
    {
        IfCanInteract();
    }
}

