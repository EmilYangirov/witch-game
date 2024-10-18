using System;
using System.Threading;
using Model.Characters;
using Model.LookItemsCollection;
using Model.ScriptableObjects;
using MVVM;
using R3;
using VContainer.Unity;

namespace ViewModels
{
    public sealed class LookItemViewModel : IInitializable, IDisposable
    {
        [Data("OnEquipStatusChange")]
        public readonly ReactiveProperty<bool> IsEquipped = new();
        
        private readonly ILookItemInvariantsCollection _itemInvariantsCollection;
        private readonly ICharacterRepository _characterRepository;
        private ICharacter _character;
        
        private string _lookItemId;

        public LookItemViewModel(ILookItemInvariantsCollection itemInvariantsCollection, ICharacterRepository characterRepository)
        {
            _itemInvariantsCollection = itemInvariantsCollection;
            _characterRepository = characterRepository;
            Initialize();
        }

        public void Dispose()
        {
            _character.OnCurrentLookChanged -= UpdateView;
        }

        public async void Initialize()
        {
            var ct = new CancellationTokenSource();
            _character = await _characterRepository.GetCharacterAsync(ct.Token);
            _character.OnCurrentLookChanged += UpdateView;
        }
        
        private void UpdateView()
        {
            var itemTuple = _itemInvariantsCollection.GetLookItemByPropertiesId(_lookItemId);
            if (null == itemTuple)
                throw new ArgumentNullException(nameof(itemTuple));
            
            IsEquipped.Value = _character.IsItemEquipped(itemTuple.Value.item);
        }
        
        [Method("Properties")]
        public void RegisterItemInCollection(LookItemProperties properties)
        {
            _lookItemId = properties.Id;
            _itemInvariantsCollection.AddLookItemProperties(properties);
            UpdateView();
        }
    }
}