namespace Variable
{
    public class NoneVariable : IMeasurable
    {
        private const float Default = 0f;
    
        public float Measure(float power, float resistance) =>
            Default;
    }
}