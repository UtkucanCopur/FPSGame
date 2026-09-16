using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //message displayed to player when looking at an interactable
    public string promptMessage;
    //add or remove an InteractionEvent component to this gameobject.
    public bool useEvents;
    
    
    
    //this function will be called from player
    public void BaseInteract()
    {
        if (useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }
    protected virtual void Interact()
    {
        //this is a template function to be overriden by subclasses

    }
}
