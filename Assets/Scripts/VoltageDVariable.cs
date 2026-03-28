using System;

internal class VoltageDVariable : IMeasurable
{
    public float Measure(float power, float resistance) =>
        MathF.Sqrt(power * resistance);
}