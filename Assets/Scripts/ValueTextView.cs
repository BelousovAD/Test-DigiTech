using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
internal class ValueTextView : MonoBehaviour
{
    [SerializeField] private string _format = "{0:F2}";
    [SerializeField] private Multimeter _multimeter;
    
    private TMP_Text _textField;

    protected Multimeter Multimeter => _multimeter;

    private void Awake() =>
        _textField = GetComponent<TMP_Text>();

    private void OnEnable()
    {
        Multimeter.ValueChanged += UpdateView;
        UpdateView();
    }

    private void OnDisable() =>
        Multimeter.ValueChanged -= UpdateView;

    private void UpdateView() =>
        _textField.text = string.Format(_format, GetValue());

    protected virtual float GetValue() =>
        Multimeter.Value;
}