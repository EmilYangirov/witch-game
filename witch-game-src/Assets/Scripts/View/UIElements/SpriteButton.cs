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

        private bool _isEnabled;

        private void Start()
        {
            _isEnabled = false;
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

        protected override void OnClick()
        {
            _isEnabled = !_isEnabled;
            SwitchSprite(_isEnabled);
        }

        public override void Disable()
        {
            _isEnabled = false;
            SwitchSprite(_isEnabled);
        }
    }
}