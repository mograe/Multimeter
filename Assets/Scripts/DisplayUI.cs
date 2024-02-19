using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class DisplayUI : MonoBehaviour
{
    private TextMeshProUGUI displayText;

    public void Initialize()
    {
        displayText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateDisplay(float value)
    {
        if (value >= 10000)
        {
            displayText.text = "E";
        }
        else if (value >= 1000)
        {
            displayText.text = value.ToString("0");
        }
        else if (value >= 100)
        {
            displayText.text = value.ToString("0.0");
        }
        else
        {
            displayText.text = value.ToString("0.00");
        }
    }
}
