using System;
using SharedKernel.View.UIElements;
using TMPro;
using UnityEngine;

namespace View.UIElements
{
    public class TMPColorButton : BaseButton
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Color _disableColor;
        [SerializeField] private Color _enableColor;
        
        private void SwitchTextColor(bool isEnabled)
        {
            if (_text == null)
                throw new ArgumentNullException(nameof(_text));
            
            _text.color = isEnabled
                ? _enableColor
                :  _disableColor;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            SwitchTextColor(_isEnabled);
        }

        public override void TurnOff()
        {
            base.TurnOff();
            SwitchTextColor(_isEnabled);
        }
    }
}