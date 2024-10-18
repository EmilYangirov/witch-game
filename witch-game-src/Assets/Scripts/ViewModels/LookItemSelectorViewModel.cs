using System;
using JetBrains.Annotations;
using Model.Characters;
using Model.ScriptableObjects;
using MVVM;
using R3;
using UnityEngine;
using VContainer.Unity;

namespace ViewModels
{
    public class LookItemSelectorViewModel : IInitializable, IDisposable
    {
        [Data("NameText")]
        public readonly ReactiveProperty<string> NameText = new();
        
        [Data("PriceText")]
        public readonly ReactiveProperty<string> PriceText = new();
        
        [Data("ItemIcon")]
        public readonly ReactiveProperty<Sprite> ItemIcon = new();

        [Data("OnSetPriceVisibility")] 
        public readonly ReactiveProperty<bool> IsPriceVisible= new();
        
        [Data("OnSetNameVisibility")] 
        public readonly ReactiveProperty<bool> IsNameVisible = new();

        [Data("PriceIcon")] 
        public readonly ReactiveProperty<Sprite> PriceIcon = new();

        [CanBeNull] 
        private LookItemProperties _currentItemProperties;

        private readonly Character _character;

        public LookItemSelectorViewModel(Character character)
        {
            _character = character;
        }
        
        public void Initialize()
        {
            _character.OnCurrentLookChanged += UpdateCharacterItemSelectorProperties;
        }

        public void Dispose()
        {
            _character.OnCurrentLookChanged -= UpdateCharacterItemSelectorProperties;
        }

        public void SetCurrentItem(LookItemProperties currentItemProperties)
        {
            _currentItemProperties = currentItemProperties;
            UpdateCharacterItemSelectorProperties();
        }
        
        private void UpdateCharacterItemSelectorProperties()
        {
            if (null == _character)
                throw new ArgumentNullException(nameof(_character));

            if (null == _currentItemProperties)
                return;
            
            NameText.Value = _currentItemProperties?.Name ?? string.Empty;
            PriceText.Value = _currentItemProperties?.BuyingStrategy?.Price.ToString() ?? string.Empty;
            ItemIcon.Value = _currentItemProperties?.Icon;

            IsPriceVisible.Value = _currentItemProperties?.IsPurchasable is true 
                                   && !_character.Inventory.IsLookItemInInventory(_currentItemProperties?.Id ?? string.Empty);

            IsNameVisible.Value = !IsPriceVisible.Value;
            PriceIcon.Value = _currentItemProperties?.BuyingStrategy?.Properties?.Icon;
        }
    }
}