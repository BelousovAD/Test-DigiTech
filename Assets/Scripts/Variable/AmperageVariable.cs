using System;

namespace Variable
{
    public class AmperageVariable : IMeasurable
    {
        public float Measure(float power, float resistance) =>
            MathF.Sqrt(power / resistance);
    }
}