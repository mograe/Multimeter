using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Multimeter multimeterPrefab;
    [SerializeField] private UIIndicator uiPrefab;
    [SerializeField] private GadgetData testGadget;

    private void Start()
    {
        var multimeter = Instantiate(multimeterPrefab);
        multimeter.Initialize();
        multimeter.SetGadget(testGadget);
       
        var ui = Instantiate(uiPrefab);
        ui.Initialize(multimeter);
    }
}
