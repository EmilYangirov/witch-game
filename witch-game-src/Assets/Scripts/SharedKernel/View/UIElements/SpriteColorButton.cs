using System;
using UnityEngine;
using UnityEngine.UI;

namespace SharedKernel.View.UIElements
{
    public class SpriteColorButton : BaseButton
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Color EnabledColor;
        [SerializeField] private Color DisabledColor;
        private void Start()
        {
            SwitchSprite(_isEnabled);
        }

        private void SwitchSprite(bool isEnabled)
        {
            if (_icon == null)
                throw new ArgumentNullException(nameof(_icon));
            
            _icon.color = isEnabled
                ? EnabledColor
                : DisabledColor;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            SwitchSprite(_isEnabled);
        }

        public override void TurnOff()
        {
            base.TurnOff();
            SwitchSprite(_isEnabled);
        }
    }
}