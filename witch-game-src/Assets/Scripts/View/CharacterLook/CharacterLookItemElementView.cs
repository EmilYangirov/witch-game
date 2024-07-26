using System;
using UnityEngine;

namespace View.CharacterLook
{
    public class CharacterLookItemElementView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private bool _isBackground;

        private void OnValidate()
        {
            this.TryGetComponent(out _renderer);
        }

        public void SetOrderingInLayer(int order)
        {
            if (_renderer == null)
            {
                Debug.LogException(new ArgumentNullException(nameof(_renderer)));
                return;
            }
            
            if (_isBackground)
                order = -order;

            _renderer.sortingOrder = order;
        }

        public void SetMaskVisibility(bool isVisibleInsideMask)
        {
            _renderer.maskInteraction = isVisibleInsideMask 
                ? SpriteMaskInteraction.None 
                : SpriteMaskInteraction.VisibleInsideMask;
        }
    }
}