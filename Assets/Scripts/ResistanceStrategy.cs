internal class ResistanceStrategy : IMeasurable
{
    public float Measure(float power, float resistance) =>
        resistance;
}