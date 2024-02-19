using TMPro;
using UnityEngine;

public class UIIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI voltageDC;
    [SerializeField] private TextMeshProUGUI amperage;
    [SerializeField] private TextMeshProUGUI voltageAC;
    [SerializeField] private TextMeshProUGUI resistence;

    public void Initialize(Multimeter multimeter)
    {
        multimeter.ChangedMode += UpdateIndicator;
    }

    private void UpdateIndicator(MultimeterMode mode, GadgetData gadget)
    {
        float value = mode.CalculateValue(gadget);
        voltageAC.text = "0";
        amperage.text = "0";
        voltageDC.text = "0";
        resistence.text = "0";

        switch (mode)
        {
            case ResistanceMode:
                resistence.text = value.ToString("0.00");
                break;

            case AmperageMode:
                amperage.text = value.ToString("0.00");
                break;

            case ACVoltageMode:
                voltageAC.text = value.ToString("0.00");
                break;

            case DCVoltageMode:
                voltageDC.text = value.ToString("0.00");
                break;
        }
    }
}
