using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SharedKernel.View.UIElements
{
    public class SnapScrollingLayoutGroup : CustomLayoutGroup
    {
        [Header("Scrolling options")] 
        [SerializeField] private ElementSize _centralElementsSize;
        [SerializeField] private float _contentMoveSpeed;
        [SerializeField] private float _changeContentPositionTime;
        [SerializeField] private bool _isLooped;

        [HideInInspector] 
        [SerializeField] private int _maxStepCount;
    
        [HideInInspector] 
        [SerializeField] private int _currentStep;

        private Vector2 _targetPosition;
        private bool _isChangingContentPosition;
        protected override void Init()
        {
            base.Init();
            _maxStepCount = _elements.Length - _visibleCount;
            _currentStep = 0;
        }

        public async void MoveOneStepNext()
        {
            if(_isChangingContentPosition)
                return;
            
            var newStep = _isVertical
                ? _currentStep - 1
                : _currentStep + 1;

            if (Mathf.Abs(newStep) > _maxStepCount)
            {
                if (_isLooped)
                {
                    ChangeFirstAndLastElementsOrdering(true);
                    _content.anchoredPosition = GetContentBasePosition();
                    newStep = _isVertical
                        ? -1
                        : 1;
                }
                else return;
            }
            
            _currentStep = newStep;
            
            _targetPosition = CalculateContentTargetPosition(_currentStep);
            await ChangeContentPosition();
        }
        
        public async void MoveOneStepBack()
        {
            if(_isChangingContentPosition)
                return;
            
            var newStep = _isVertical
                ? _currentStep + 1
                : _currentStep - 1;
            
            if ((_isVertical && newStep > 0) || (!_isVertical && newStep < 0))
            {
                if (_isLooped)
                {
                    ChangeFirstAndLastElementsOrdering(false);
                    _content.anchoredPosition = CalculateContentTargetPosition(_isVertical ? -1 : 1);
                    newStep = 0;
                }
                else return;
            }
            
            _currentStep = newStep;
            
            _targetPosition = CalculateContentTargetPosition(_currentStep);
            await ChangeContentPosition();
        }

        private void ChangeFirstAndLastElementsOrdering(bool changeFirst)
        {
            if (changeFirst)
            {
                
                _elements = _elements.Skip(1).Concat(_elements.Take(1)).ToArray();
                _content.transform.GetChild(0).SetAsLastSibling();
            }
            else
            {
                _elements = _elements.Skip(_elements.Length - 1).Concat(_elements.Take(_elements.Length - 1)).ToArray();
                _content.transform.GetChild(transform.childCount - 1).SetAsFirstSibling();
            }
            
            SolveElements();
        }

        protected override void SolveElements()
        {
            base.SolveElements();
           _targetPosition = CalculateContentTargetPosition(_currentStep);

           if (!_isChangingContentPosition)
           {
               SetContentPosition();
           }
        }

        private Vector2 CalculateContentTargetPosition(int step)
        {
            var basePosition = GetContentBasePosition();
            return _isVertical
                ? new Vector2(basePosition.x, basePosition.y - _stepOffset * step)
                : new Vector2(basePosition.x + _stepOffset * step, basePosition.y);
        }

        private async UniTask ChangeContentPosition()
        {
            Debug.Log(_currentStep);
            _isChangingContentPosition = true;
            float timer = 0;

            while (timer < _changeContentPositionTime)
            {
                _content.anchoredPosition = Vector2.MoveTowards(_content.anchoredPosition, _targetPosition,
                    _contentMoveSpeed * Time.deltaTime);
                timer += Time.deltaTime;
                await UniTask.Yield();
            }

            SetContentPosition();
            _isChangingContentPosition = false;
        }

        private void SetContentPosition()
        {
            _content.anchoredPosition = CalculateContentTargetPosition(_currentStep);
        }
    }
}
