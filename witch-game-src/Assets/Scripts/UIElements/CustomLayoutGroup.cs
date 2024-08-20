
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(RectTransform))]
public class CustomLayoutGroup : MonoBehaviour
{
    [Header ("Main options")]
    [SerializeField] private bool _isVertical;
    
    [SerializeField] private int _visibleCount;

    [SerializeField] private bool _isAllowPartialElements;

    [SerializeField] private float _maxMainSide;

    [SerializeField] private float _minSpacing;

    [Header("Elements options")] 
    [SerializeField] private ElementSize _minSize;
    [SerializeField] private ElementSize _maxSize;
    
    [HideInInspector]
    [SerializeField] private RectTransform[] _elements;

    private RectTransform _rectTransform;

    private void OnValidate()
    {
        TryGetComponent(out _rectTransform);
        _elements = GetChildElements();
        SolveElements();
    }

    private void Start()
    {
        SolveElements();
    }

    public void Update()
    {
        SolveElements();
    }

    private RectTransform[] GetChildElements()
    {
        return this.transform
        .Cast<Transform>()
        .Select(t => t.gameObject.GetComponent<RectTransform>())
        .ToArray();
    }

    public void SolveElements()
    {
        var mainSideSize = _isVertical
            ? _rectTransform.rect.height
            : _rectTransform.rect.width;
        
        if (mainSideSize > _maxMainSide)
            mainSideSize = _maxMainSide;

        var elementSize = CalculateNewSize(mainSideSize, out var spacing);
        SetElementsSize(elementSize);
        SetElementsPositions(elementSize, spacing);
    }

    private void SetElementsPositions(ElementSize elementSize, float spacing)
    {
        var mainSize = _isVertical ? elementSize.Height : elementSize.Width;
        var mainSideSize = _isVertical
            ? _rectTransform.rect.height
            : _rectTransform.rect.width;
        var mainSidePadding = mainSideSize > _maxMainSide
            ? (mainSideSize - _maxMainSide) / 2
            : 0;
        var currentPosition = _isAllowPartialElements 
            ? 0 + mainSidePadding 
            : (mainSize / 2) + mainSidePadding;
            
        for (int i = 0; i < _elements.Length; i++)
        {
            _elements[i].anchoredPosition = _isVertical
                ? new Vector2(0, currentPosition)
                : new Vector2(currentPosition, 0);

            if (i != _elements.Length - 1)
            {
                currentPosition = currentPosition + mainSize + spacing;
            }
        }
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

        spacing = (mainSideSize - elementsRequiredSize) / (_visibleCount - 1);
        return _maxSize;
    }
}

[System.Serializable]
public struct ElementSize
{
    public float Width;
    public float Height;
}
