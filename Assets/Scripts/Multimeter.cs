using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class Multimeter : MonoBehaviour
{
    private const int Backward = -1;
    private const int Default = 0;
    private const int Forward = 1;
    
    [SerializeField][Min(0f)] private float _inputResistance = 1000f;
    [SerializeField][Min(0f)] private float _inputPower = 400f;

    private readonly VariableType[]
        _variableTypes = Enum.GetValues(typeof(VariableType)).Cast<VariableType>().ToArray();
    private readonly Dictionary<VariableType, IMeasurable> _variables = new ()
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

        private set
        {
            _value = value;
            ValueChanged?.Invoke();
        }
    }

    public void Back() =>
        Move(Backward);

    public void Next() =>
        Move(Forward);

    private void Move(int direction)
    {
        Value = Default;
        _index = (_variableTypes.Length + _index + direction) % _variableTypes.Length;
        VariableChanged?.Invoke();
        Value = _variables[_variableTypes[_index]].Measure(_inputPower, _inputResistance);
    }
}