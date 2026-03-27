using UnityEngine;

internal class ConcreteValueTextView : ValueTextView
{
    private const float Default = 0;
    
    [SerializeField] private StrategyType _type;

    protected override float GetValue() =>
        Multimeter.Strategy == _type ? Multimeter.Value : Default;
}