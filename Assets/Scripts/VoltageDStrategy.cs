using System;

internal class VoltageDStrategy : IMeasurable
{
    public float Measure(float power, float resistance) =>
        MathF.Sqrt(power * resistance);
}