using System;
using R3;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace View.Base
{
    [RequireComponent(typeof(Image))]
    public class VerticalButtonView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Sprite _enabledSprite;
        [SerializeField] private Sprite _disabledSprite;
        private Image _image;
        private int _buttonId;
        
        public Subject<int> ButtonClicked;
        private void OnValidate()
        {
            TryGetComponent(out _image);

            if (null == _image)
            {
                Debug.LogException(new ArgumentNullException(nameof(_image)));
                return;
            }

            SwitchSprite(false);
        }

        public void SwitchSprite(bool isEnabled)
        {
            if (_image == null)
                throw new ArgumentNullException(nameof(_image));
            
            _image.sprite = isEnabled ? _enabledSprite : _disabledSprite;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            ButtonClicked.OnNext(_buttonId);
        }
    }
}