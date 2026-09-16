using UnityEngine;

public class Cube : Interactable
{
    MeshRenderer mesh;
    public Color[] colors;
    private int colorIndex;


    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.material.color = Color.red;
    }

    protected override void Interact()
    {
        colorIndex++;
        if (colorIndex > colors.Length -1)
        {
            colorIndex = 0;
        }

        mesh.material.color = colors[colorIndex];
    }

}
