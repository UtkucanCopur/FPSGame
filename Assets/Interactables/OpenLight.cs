using UnityEngine;

public class OpenLight : Interactable
{
    public GameObject lightobject;
    public bool isLightOpen = false;

    protected override void Interact()
    {
        isLightOpen = !isLightOpen;
        if (isLightOpen)
            lightobject.SetActive(true);
        else
            lightobject.SetActive(false);
    }
}
