using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(MeshRenderer))]
public class RegulatorEmission : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private const string EmissionKey = "_EMISSION";

    private Material _material;

    private void Awake() =>
        _material = GetComponent<MeshRenderer>().material;

    public void OnPointerEnter(PointerEventData eventData) =>
        _material.EnableKeyword(EmissionKey);

    public void OnPointerExit(PointerEventData eventData) =>
        _material.DisableKeyword(EmissionKey);
}
