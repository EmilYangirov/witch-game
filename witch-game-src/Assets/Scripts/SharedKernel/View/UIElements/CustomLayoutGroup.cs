using System.Linq;
using UnityEngine;

namespace SharedKernel.View.UIElements
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(RectTransform))]
    public class CustomLayoutGroup : MonoBehaviour
    {
        [Header("Main options")] [SerializeField]
        protected bool _isVertical;

        [SerializeField] private float _maxContentMainSide;
        [SerializeField] private float _minSpacing;
        [SerializeField] protected RectTransform _content;

        [Header("Elements options")] [SerializeField]
        private ElementSize _minSize;

        [SerializeField] private ElementSize _maxSize;
        [SerializeField] private ElementAlignmentType ElementAlignment;
        [SerializeField] protected int _visibleCount;
        [SerializeField] private float _elementsAxisPadding;
        [SerializeField] private bool _isAllowPartialElements;

        [HideInInspector] 
        [SerializeField] protected RectTransform[] _elements;


        [SerializeField] private RectTransform _rectTransform;

        protected float _stepOffset { get; private set; }

        private void OnValidate()
        {
            Init();
        }

        protected virtual void Init()
        {
            TryGetComponent(out _rectTransform);

            if (null == _content)
            {
                var content = new GameObject("Content")
                    .AddComponent<RectTransform>();
                _content = content;
                _content.transform.SetParent(this.transform);
            }

            _content.anchoredPosition = GetContentBasePosition();
            _elements = GetContentChildElements();
            SolveElements();
        }

        private void OnRectTransformDimensionsChange()
        {
            SolveElements();
        }

        private RectTransform[] GetContentChildElements()
        {
            return _content.transform
                .Cast<Transform>()
                .Select(t => t.gameObject.GetComponent<RectTransform>())
                .ToArray();
        }

        protected virtual void SolveElements()
        {
            float mainSideSize = _isVertical
                ? _rectTransform.rect.height
                : _rectTransform.rect.width;

            if (mainSideSize > _maxContentMainSide)
                mainSideSize = _maxContentMainSide;

            SetContentSize(mainSideSize);
            var elementSize = CalculateNewSize(mainSideSize, out var spacing);

            SetElementsSize(elementSize);
            SetElementsPositions(elementSize, mainSideSize, spacing);
        }

        private void SetElementsPositions(ElementSize elementSize, float mainSideSize, float spacing)
        {
            var elementMainSize = _isVertical ? elementSize.Height : elementSize.Width;
            var mainSidePadding = mainSideSize > _maxContentMainSide
                ? (mainSideSize - _maxContentMainSide) / 2
                : 0;
            var mainPosition = _isVertical
                ? _isAllowPartialElements ? 0 - mainSidePadding : -(elementMainSize / 2) - mainSidePadding
                : _isAllowPartialElements
                    ? 0 + mainSidePadding
                    : (elementMainSize / 2) + mainSidePadding;

            _stepOffset = elementMainSize + spacing;

            var secondSidePosition = true switch
            {
                _ when ElementAlignment == ElementAlignmentType.Upper && !_isVertical =>
                    _content.rect.height/2 - elementSize.Height/2,
                _ when ElementAlignment == ElementAlignmentType.Center && !_isVertical =>
                    0,
                _ when ElementAlignment == ElementAlignmentType.Bottom && !_isVertical =>
                    -_content.rect.height/2 + elementSize.Height/2,
                _ when ElementAlignment == ElementAlignmentType.Upper && _isVertical =>
                    0,
                _ when ElementAlignment == ElementAlignmentType.Center && _isVertical =>
                    -_content.rect.height / 2,
                _ when ElementAlignment == ElementAlignmentType.Bottom && _isVertical =>
                    -_content.rect.height,
                _ => 0
            };

            for (int i = 0; i < _elements.Length; i++)
            {
                _elements[i].anchoredPosition = _isVertical
                    ? new Vector2(_elementsAxisPadding, mainPosition + secondSidePosition)
                    : new Vector2(mainPosition, secondSidePosition + _elementsAxisPadding);

                if (i != _elements.Length - 1)
                {
                    mainPosition = _isVertical
                        ? mainPosition - _stepOffset
                        : mainPosition + _stepOffset;
                }
            }
        }

        private void SetContentSize(float mainSize)
        {
            _content.sizeDelta = _isVertical
                ? new Vector2(_rectTransform.sizeDelta.x, mainSize)
                : new Vector2(mainSize, _rectTransform.sizeDelta.y);
        }

        protected virtual Vector2 GetContentBasePosition()
        {
            return Vector2.zero;
        }

        private void SetElementsSize(ElementSize size)
        {
            foreach (var element in _elements)
            {
                element.sizeDelta = new Vector2(size.Width, size.Height);
            }
        }

        private ElementSize CalculateNewSize(float mainSideSize, out float spacing)
        {
            var elementPreferedSize = _isVertical ? _maxSize.Height : _maxSize.Width;
            var elementsRequiredSize = _isAllowPartialElements
                ? elementPreferedSize * (_visibleCount - 1)
                : elementPreferedSize * _visibleCount;

            var minSpacingRequiredSize = _minSpacing * (_visibleCount - 1);

            if (mainSideSize - elementsRequiredSize - minSpacingRequiredSize < 0)
            {
                var remainingSize = mainSideSize - minSpacingRequiredSize;
                var elementScaleFactor = _isAllowPartialElements
                    ? (remainingSize / (_visibleCount - 1)) / elementPreferedSize
                    : (remainingSize / (_visibleCount)) / elementPreferedSize;

                spacing = _minSpacing;
                var resultSize = new ElementSize
                {
                    Width = elementScaleFactor * _maxSize.Width,
                    Height = elementScaleFactor * _maxSize.Height
                };

                if (_minSize.Height <= resultSize.Height && _minSize.Width <= resultSize.Width)
                {
                    return resultSize;
                }
                else
                {
                    return _minSize;
                }
            }

            spacing = _visibleCount > 1
                ? (mainSideSize - elementsRequiredSize) / (_visibleCount - 1)
                : mainSideSize - elementsRequiredSize;
            return _maxSize;
        }
    }

    [System.Serializable]
    public struct ElementSize
    {
        public float Width;
        public float Height;
    }

    public enum ElementAlignmentType
    {
        Upper,
        Center,
        Bottom,
    }
}
