using UnityEngine;

[RequireComponent(typeof(Outline))]
public abstract class Interactable : MonoBehaviour
{
    private Outline outline;
    protected bool active;

    public virtual void Intitialize()
    {
        outline = GetComponent<Outline>();
        outline.OutlineWidth = 0;
    }

    public void OnMouseEnter()
    {
        outline.OutlineWidth = 3;
        active = true;
    }

    public void OnMouseExit()
    {
        outline.OutlineWidth = 0;
        active = false;
    }
}
