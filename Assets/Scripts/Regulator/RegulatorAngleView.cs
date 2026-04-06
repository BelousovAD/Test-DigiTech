using System;
using System.Collections.Generic;
using UnityEngine;
using Variable;

namespace Regulator
{
    internal class RegulatorAngleView : MonoBehaviour
    {
        [SerializeField] private Multimeter.Multimeter _multimeter;
        [SerializeField] private Regulator _regulator;
        [SerializeField] private List<VariableAngle> _regulatorAngles = new ();

        private readonly Dictionary<VariableType, float> _angles = new ();
        private Vector3 _defaultAngle;

        private void Awake()
        {
            _regulatorAngles.ForEach(angle => _angles.Add(angle.Type, angle.Value));
            _defaultAngle = transform.eulerAngles;
        }

        private void OnEnable()
        {
            _multimeter.VariableChanged += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _multimeter.VariableChanged -= UpdateView;

        private void UpdateView() =>
            transform.eulerAngles = _defaultAngle + new Vector3(0f, 0f, _angles[_multimeter.Variable]);

        [Serializable]
        private struct VariableAngle
        {
            public VariableType Type;
            public float Value;
        }
    }
}