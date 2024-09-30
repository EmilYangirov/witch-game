using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace View.CharacterLook
{
    [RequireComponent(typeof(SortingGroup))]
    public class GroupElementsOrdering : CharacterLookItemElementOrdering
    {
        [SerializeField] private SortingGroup _sortingGroup;
        private void OnValidate()
        {
            TryGetComponent(out _sortingGroup);
        }
        public override void SetLookItemElementOrdering(int order)
        {
            if (_sortingGroup == null)
            {
                Debug.LogException(new ArgumentNullException(nameof(_sortingGroup)));
                return;
            }
            
            if (_isBackground)
                order = -order;

            _sortingGroup.sortingOrder = order;
        }
    }
}