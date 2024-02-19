using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RegulatorInteract))]
public class Regulator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2f;
    private bool rotating = false;

    private Multimeter multimeter;
    private RegulatorInteract interact;

    public void Initialize(Multimeter multimeter)
    {
        this.multimeter = multimeter;
        interact = GetComponent<RegulatorInteract>();
        interact.Intitialize();
    }

    private IEnumerator Rotate(float rotation, int newModeIndex)
    {
        rotating = true;

        Quaternion targetRotation = Quaternion.Euler(0, 0, rotation);
        for (float t = 0; t <= 1; t += Time.deltaTime * rotationSpeed)
        {
            var tMultiplied = t * t;
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, tMultiplied);
            yield return null;
        }

        transform.rotation = targetRotation;
        rotating = false;

        multimeter.SetMode(newModeIndex);
    }

    public void RotateLeft()
    {
        if (rotating) return;

        var currentIndex = multimeter.CurrentModeIndex;
        var previousIndex = multimeter.ClampIndex(currentIndex - 1);
        var degree = multimeter.MultimeterModes[previousIndex].Degree;
        StartCoroutine(Rotate(degree, previousIndex));
    }

    public void RotateRight()
    {
        if (rotating) return;

        var currentIndex = multimeter.CurrentModeIndex;
        var nextIndex = multimeter.ClampIndex(currentIndex + 1);
        var degree = multimeter.MultimeterModes[nextIndex].Degree;
        StartCoroutine(Rotate(degree, nextIndex));
    }
}
