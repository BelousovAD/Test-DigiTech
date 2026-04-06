using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Regulator
{
    internal class Regulator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Multimeter.Multimeter _multimeter;
    
        private bool _isInteractable;

        public event Action InteractivityChanged;
    
        public bool IsInteractable
        {
            get => _isInteractable;

            private set
            {
                _isInteractable = value;
                InteractivityChanged?.Invoke();
            }
        }

        public void Update()
        {
            if (!IsInteractable)
            {
                return;
            }
        
            float direction = -Input.mouseScrollDelta.y;

            switch (direction)
            {
                case > 0:
                    _multimeter.Next();
                    break;
                case < 0:
                    _multimeter.Back();
                    break;
            }
        }
    
        public void OnPointerEnter(PointerEventData eventData) =>
            IsInteractable = true;

        public void OnPointerExit(PointerEventData eventData) =>
            IsInteractable = false;
    }
}