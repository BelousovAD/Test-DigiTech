using UnityEngine;

internal class ConcreteValueTextView : ValueTextView
{
    private const float Default = 0;
    
    [SerializeField] private VariableType _type;

    protected override float GetValue() =>
        Multimeter.Variable == _type ? Multimeter.Value : Default;
}