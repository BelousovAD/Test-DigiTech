internal class ResistanceVariable : IMeasurable
{
    public float Measure(float power, float resistance) =>
        resistance;
}