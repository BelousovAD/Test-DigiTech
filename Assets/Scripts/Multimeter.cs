using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class Multimeter : MonoBehaviour
{
    [SerializeField][Min(0f)] private float _inputResistance = 1000f;
    [SerializeField][Min(0f)] private float _inputPower = 400f;

    private readonly VariableType[]
        _variableTypes = Enum.GetValues(typeof(VariableType)).Cast<VariableType>().ToArray();
    private readonly Dictionary<VariableType, IMeasurable> _strategies = new ()
    {
        [VariableType.None] = new NoneVariable(),
        [VariableType.Amperage] = new AmperageVariable(),
        [VariableType.Resistance] = new ResistanceVariable(),
        [VariableType.VoltageA] = new VoltageAVariable(),
        [VariableType.VoltageD] = new VoltageDVariable(),
    };
    private int _index;
    private float _value;

    public event Action VariableChanged;
    public event Action ValueChanged;

    public VariableType Variable => _variableTypes[_index];

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
        _index = (_index + 1) % _variableTypes.Length;
        VariableChanged?.Invoke();
        _strategies[_variableTypes[_index]].Measure(_inputPower, _inputResistance);
    }
}