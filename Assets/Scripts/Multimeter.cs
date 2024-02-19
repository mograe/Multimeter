using System;
using System.Collections.Generic;
using UnityEngine;

public class Multimeter : MonoBehaviour
{
    public int CurrentModeIndex { get; private set; }
    public IList<MultimeterMode> MultimeterModes
    {
        get { return multimeterModes.AsReadOnly(); }
    }
    public event Action<MultimeterMode, GadgetData> ChangedMode;

    private MultimeterMode currentMode;
    private List<MultimeterMode> multimeterModes = new List<MultimeterMode>();
    private GadgetData currentGadget;

    [SerializeField] private Regulator regulator;
    [SerializeField] private DisplayUI display;

    public void Initialize()
    {
        multimeterModes.Add(new DCVoltageMode(45));
        multimeterModes.Add(new NeutralMode(90));
        multimeterModes.Add(new ResistanceMode(135));
        multimeterModes.Add(new AmperageMode(225));
        multimeterModes.Add(new ACVoltageMode(315));

        display.Initialize();
        regulator.Initialize(this);

        SetMode(1);
    }

    public void SetMode(int newIndex)
    {
        CurrentModeIndex = ClampIndex(newIndex);
        currentMode = multimeterModes[CurrentModeIndex];
        
        if (!currentGadget) return;

        ChangedMode?.Invoke(currentMode, currentGadget);
        display.UpdateDisplay(currentMode.CalculateValue(currentGadget));
    }

    public int ClampIndex(int newIndex)
    {
        if (newIndex > multimeterModes.Count - 1)
        {
            newIndex = 0;
        }
        else if (newIndex < 0)
        {
            newIndex = multimeterModes.Count - 1;
        }

        return newIndex;
    }

    public void SetGadget(GadgetData gadgetData)
    {
        currentGadget = gadgetData;

        display.UpdateDisplay(currentMode.CalculateValue(currentGadget));
    }
}