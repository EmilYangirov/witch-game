using UnityEngine;

namespace SharedKernel.View.UIElements
{
    public class RadioButtonsGroup : MonoBehaviour
    {
        [SerializeField] private BaseButton[] _buttons;
        private int _lastId = -1;

        private void OnValidate()
        {
            _buttons = GetComponentsInChildren<BaseButton>();
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].SetId(i);
            }
        }

        private void OnRadioButtonClick(int buttonId)
        {
            if (_lastId != -1 && _lastId != buttonId)
            {
                _buttons[_lastId].Disable();
            }

            _lastId = buttonId;
        }
        
        private void OnEnable()
        {
            foreach (var button in _buttons)
            {
                button.OnButtonClick += OnRadioButtonClick;
            }
        }
        
        private void OnDisable()
        {
            foreach (var button in _buttons)
            {
                button.OnButtonClick -= OnRadioButtonClick;
            }
        }
    }
}