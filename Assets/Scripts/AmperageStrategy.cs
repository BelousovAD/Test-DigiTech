using System;

internal class AmperageStrategy : IMeasurable
{
    public float Measure(float power, float resistance) =>
        MathF.Sqrt(power / resistance);
}