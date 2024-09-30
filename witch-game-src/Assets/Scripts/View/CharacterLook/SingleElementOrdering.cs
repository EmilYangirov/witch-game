using System;
using UnityEngine;

namespace View.CharacterLook
{
    public class SingleElementOrdering : CharacterLookItemElementOrdering
    {
        [SerializeField] protected SpriteRenderer _renderer;

        private void OnValidate()
        {
            this.TryGetComponent(out _renderer);
        }

        public override void SetLookItemElementOrdering(int order)
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
    }
}