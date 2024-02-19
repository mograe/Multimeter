using UnityEngine;

public abstract class MultimeterMode
{
    public float Degree { get; private set; }

    public MultimeterMode(float degree)
    {
        Degree = degree;
    }

    public abstract float CalculateValue(GadgetData gadgetData);

}

public class ACVoltageMode : MultimeterMode
{
    public ACVoltageMode(float degree) : base(degree)
    {
    }

    public override float CalculateValue(GadgetData gadgetData)
    {
        return 0.01f;
    }
}

public class ResistanceMode : MultimeterMode
{
    public ResistanceMode(float degree) : base(degree)
    {
    }

    public override float CalculateValue(GadgetData gadgetData)
    {
        return gadgetData.Resistance;
    }
}

public class AmperageMode : MultimeterMode
{
    public AmperageMode(float degree) : base(degree)
    {
    }

    public override float CalculateValue(GadgetData gadgetData)
    {
        return Mathf.Sqrt(gadgetData.Power / gadgetData.Resistance);
    }
}

public class DCVoltageMode : MultimeterMode
{
    public DCVoltageMode(float degree) : base(degree)
    {
    }

    public override float CalculateValue(GadgetData gadgetData)
    {
        return Mathf.Sqrt(gadgetData.Power * gadgetData.Resistance);
    }
}

public class NeutralMode : MultimeterMode
{
    public NeutralMode(float degree) : base(degree)
    {
    }

    public override float CalculateValue(GadgetData gadgetData)
    {
        return 0f;
    }
}