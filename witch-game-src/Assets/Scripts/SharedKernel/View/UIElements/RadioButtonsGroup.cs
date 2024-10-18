using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SharedKernel.View.UIElements
{
    public class RadioButtonsGroup : MonoBehaviour
    {
        [SerializeField] private List<GroupButton> _buttons;
        [SerializeField] private bool _isButtonsCanTurnOffItself;
            
        [SerializeField] 
        [HideInInspector] private int _lastEnabledInStartId;
        
        private int _lastId = -1;

        
        private void OnValidate()
        {
            Init();
        }

        private void Init()
        {
            AddButtonsFromChildrens();
            SolveButtonsEnabledInStartStatuses();
        }

        private void Start()
        {
            if (_lastEnabledInStartId == -1)
                return;
            
            _buttons[_lastEnabledInStartId].Value.TurnOn();
            OnRadioButtonClick(_lastEnabledInStartId);
        }

        private void AddButtonsFromChildrens()
        {
            var buttons = GetComponentsInChildren<BaseButton>();
            
            foreach (var item in buttons)
            {
                item.SetCanTurnOffFlag(_isButtonsCanTurnOffItself);
            }
            
            for (int i = 0; i < buttons.Length; i++)
            {
                var isExist = _buttons.Any(b => b.Value.Equals(buttons[i]));
                if (isExist)
                    return;
                
                _buttons.Add(new GroupButton()
                {
                    Value = buttons[i]
                });
                buttons[i].SetId(i);
            }
        }

        public void SolveButtonsEnabledInStartStatuses()
        {
            var enabledButtons = _buttons.Where(b => b.IsEnabledInStart).ToList();

            if (enabledButtons.Count > 1)
            {
                _buttons[_lastEnabledInStartId].IsEnabledInStart = false;
                _lastEnabledInStartId = _buttons.IndexOf(enabledButtons.FirstOrDefault(b => 
                    !Equals(b, _buttons[_lastEnabledInStartId])));
            }
            else
            {
                _lastEnabledInStartId = enabledButtons.FirstOrDefault() != null
                    ? _buttons.IndexOf(enabledButtons.First())
                    : -1;
            }
        }

        private void OnRadioButtonClick(int buttonId)
        {
            if (_lastId == buttonId && !_isButtonsCanTurnOffItself)
                return;
            
            if (_lastId != -1 && _lastId != buttonId)
            {
                _buttons[_lastId].Value.TurnOff();
            }

            _lastId = buttonId;
        }
        
        private void OnEnable()
        {
            foreach (var button in _buttons)
            {
                button.Value.OnButtonClickWithIdSending += OnRadioButtonClick;
            }
        }
        
        private void OnDisable()
        {
            foreach (var button in _buttons)
            {
                button.Value.OnButtonClickWithIdSending -= OnRadioButtonClick;
            }
        }
    }

    [System.Serializable]
    public class GroupButton
    {
        public BaseButton Value;
        public bool IsEnabledInStart;
    }
}