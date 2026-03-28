using System;

internal class AmperageVariable : IMeasurable
{
    public float Measure(float power, float resistance) =>
        MathF.Sqrt(power / resistance);
}