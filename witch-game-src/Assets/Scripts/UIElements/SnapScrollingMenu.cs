using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


namespace UIElements
{
    [RequireComponent(typeof(RectTransform))]
    public class SnapScrollingMenu : MonoBehaviour
    {
        [SerializeField] private ContentGroup _contentGroup;
        [SerializeField] private bool _isVertical;
        
        [Header ("Elements options")]
        [SerializeField] private int _visibleElementsCount;
        [SerializeField] public int _widthRatio;
        [SerializeField] public int _heightRatio;
        [SerializeField] public int _maxWidth;
        [SerializeField] public int _maxHeight;
        
        private List<RectTransform> _childRects;
        
        private void OnValidate()
        {
            if(_contentGroup.LayoutGroup == null)
                return;
            
            _contentGroup.LayoutGroup.TryGetComponent(out _contentGroup.RectTransform);
            _childRects = _contentGroup.RectTransform.transform
                .Cast<Transform>()
                .Select(t => t.gameObject.GetComponent<RectTransform>())
                .ToList();
           
            ConfigureElements();
        }

        private void Start()
        {
            ConfigureElements();
        }

        private void Update()
        {
            ConfigureElements();
        }

        private void ConfigureElements()
        {
            if (_visibleElementsCount <= 0)
                return;
            
            if (_widthRatio <= 0)
                return;
            
            if (_heightRatio <= 0)
                return;
            
            if (null == _contentGroup)
                throw new ArgumentNullException(nameof(_contentGroup));

            var currentMainSide = _isVertical
                ? _contentGroup.RectTransform.rect.width
                : _contentGroup.RectTransform.rect.height;
            
            var newWidth = _isVertical
                ? currentMainSide
                : currentMainSide * _widthRatio / _heightRatio;
            
            var newHeight = !_isVertical
                ? currentMainSide
                : currentMainSide * _heightRatio / _widthRatio;

            var paddingFactor = _isVertical
                ? _contentGroup.LayoutGroup.padding.top + _contentGroup.LayoutGroup.padding.bottom
                : _contentGroup.LayoutGroup.padding.right + _contentGroup.LayoutGroup.padding.left;
            
            var spacing = _isVertical
                ? (_contentGroup.RectTransform.rect.height - paddingFactor - _visibleElementsCount * newHeight) /
                  (_visibleElementsCount - 1)
                : (_contentGroup.RectTransform.rect.width - paddingFactor - _visibleElementsCount * newWidth) /
                  (_visibleElementsCount - 1);
            
            _contentGroup.LayoutGroup.spacing = spacing;
            
            foreach (var element in _childRects)
            {
                element.sizeDelta = new Vector2(newHeight, newWidth);
            }
            
        }
    }

    [System.Serializable]
    public class ContentGroup
    {
        public HorizontalOrVerticalLayoutGroup LayoutGroup;
        public RectTransform RectTransform;
    }
}