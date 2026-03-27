using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class Multimeter : MonoBehaviour
{
    [SerializeField][Min(0f)] private float _inputResistance = 1000f;
    [SerializeField][Min(0f)] private float _inputPower = 400f;

    private readonly StrategyType[] _types = Enum.GetValues(typeof(StrategyType)).Cast<StrategyType>().ToArray();
    private readonly Dictionary<StrategyType, IMeasurable> _strategies = new ()
    {
        [StrategyType.None] = new NoneStrategy(),
        [StrategyType.Amperage] = new AmperageStrategy(),
        [StrategyType.Resistance] = new ResistanceStrategy(),
        [StrategyType.VoltageA] = new VoltageAStrategy(),
        [StrategyType.VoltageD] = new VoltageDStrategy(),
    };
    private int _index;
    private float _value;

    public event Action StrategyChanged;
    public event Action ValueChanged;

    public StrategyType Strategy => _types[_index];

    public float Value
    {
        get => _value;

        set
        {
            _value = value;
            ValueChanged?.Invoke();
        }
    }

    public void Next()
    {
        _index = (_index + 1) % _types.Length;
        StrategyChanged?.Invoke();
        _strategies[_types[_index]].Measure(_inputPower, _inputResistance);
    }
}