using MVVM;
using SharedKernel.View.Base;
using SharedKernel.View.UIElements;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View.LookItemSelector
{
    public class LookItemSelectorView : BaseView
    {
        public BaseButton SelectButton;
        
        [Data("NameText")] 
        public TMP_Text NameText;
        
        [Data("PriceText")] 
        public TMP_Text PriceText;

        [Data("ItemIcon")] 
        public Image ItemIconRenderer;
        
        [Data("PriceIcon")] 
        public Image PriceIconRenderer;

        [SerializeField] 
        private GameObject _priceGameObject;
        
        [SerializeField] 
        private GameObject _nameGameObject;

        [Method("OnSetPriceVisibility")]
        public void SetPriceVisibility(bool isVisible)
        {
            _priceGameObject.SetActive(isVisible);
        }
        
        [Method("OnSetNameVisibility")]
        public void SetNameVisibility(bool isVisible)
        {
            _nameGameObject.SetActive(isVisible);
        }
    }
}