using UnityEngine;

public class RegulatorInteract : Interactable
{
    private Regulator regulator;
    private readonly string scrollAxis = "Mouse ScrollWheel";

    public override void Intitialize()
    {
        base.Intitialize();
        regulator = GetComponent<Regulator>();
    }

    private void Update()
    {
        if (!active)
        {
            return;
        }
        if (Input.GetAxis(scrollAxis) < 0f)
        {
            regulator.RotateLeft();
            return;
        }
        if (Input.GetAxis(scrollAxis) > 0f)
        {
            regulator.RotateRight();
            return;
        }
    }
}
