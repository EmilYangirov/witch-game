using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SharedKernel.View.UIElements
{
    public abstract class BaseButton : MonoBehaviour, IPointerClickHandler
    {
        public Action<int> OnButtonClick;
        
        [field: SerializeField]
        public int Id { get; private set; }
        protected abstract void OnClick();
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick();
            OnButtonClick.Invoke(Id);
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public abstract void Disable();
    }
}