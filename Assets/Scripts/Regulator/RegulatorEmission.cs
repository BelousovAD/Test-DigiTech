using UnityEngine;

namespace Regulator
{
    [RequireComponent(typeof(MeshRenderer))]
    public class RegulatorEmission : MonoBehaviour
    {
        private const string EmissionKey = "_EMISSION";

        [SerializeField] private Regulator _regulator;
    
        private Material _material;

        private void Awake() =>
            _material = GetComponent<MeshRenderer>().material;

        private void OnEnable()
        {
            _regulator.InteractivityChanged += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _regulator.InteractivityChanged -= UpdateView;

        private void UpdateView()
        {
            if (_regulator.IsInteractable)
            {
                _material.EnableKeyword(EmissionKey);
            }
            else
            {
                _material.DisableKeyword(EmissionKey);
            }
        }
    }
}
