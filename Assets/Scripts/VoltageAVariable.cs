internal class VoltageAVariable : IMeasurable
{
    private const float Default = 0.01f;
    
    public float Measure(float power, float resistance) =>
        Default;
}