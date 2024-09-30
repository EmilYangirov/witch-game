using System;
using SharedKernel.View.UIElements;
using UnityEngine;
using UnityEngine.UI;

namespace View.UIElements
{
    public class SpriteButton : BaseButton
    {
        [SerializeField] private Sprite _disabledSprite;
        [SerializeField] private Sprite _enabledSprite;
        [SerializeField] private Image _icon;

        private void Start()
        {
            SwitchSprite(_isEnabled);
        }

        private void SwitchSprite(bool isEnabled)
        {
            if (_icon == null)
                throw new ArgumentNullException(nameof(_icon));
            
            _icon.sprite = isEnabled
                ? _enabledSprite
                : _disabledSprite;
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