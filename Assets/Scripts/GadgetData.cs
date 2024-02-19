using UnityEngine;

[CreateAssetMenu(menuName = "Gadget Data")]
public class GadgetData : ScriptableObject
{
    [field: SerializeField] public float Resistance { get; private set; }
    [field: SerializeField] public float Power { get; private set; }
}
