using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SharedKernel.View.UIElements
{
    public abstract class BaseButton : MonoBehaviour, IPointerClickHandler
    {
        public Action<int> OnButtonClick;
        [SerializeField] private bool _isCanTurnOffItself;
        
        protected bool _isEnabled;
        
        [field: SerializeField]
        public int Id { get; private set; }
        public void OnPointerClick(PointerEventData eventData)
        {
            ChangeEnabledStatus();
            OnButtonClick.Invoke(Id);
        }

        private void Awake()
        {
            TurnOff();
        }

        private void ChangeEnabledStatus()
        {
            switch (_isCanTurnOffItself)
            {
                case false when !_isEnabled:
                    TurnOn();
                    break;
                case true when _isEnabled:
                    TurnOff();
                    break;
                case true when !_isEnabled:
                    TurnOn();
                    break;
                default: return;
            }
        }
        public void SetId(int id)
        {
            Id = id;
        }

        public virtual void TurnOn()
        {
            _isEnabled = true;
        }

        public virtual void TurnOff()
        {
            _isEnabled = false;
        }

        public void SetCanTurnOffFlag(bool value)
        {
            _isCanTurnOffItself = value;
        }
    }
}