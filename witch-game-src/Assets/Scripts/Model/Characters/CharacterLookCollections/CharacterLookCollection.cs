using System.Collections.Generic;
using System.Linq;
using Model.Characters.LookItems;

namespace Model.Characters.CharacterLookCollections
{
    public abstract class CharacterLookCollection
    {
        public List<LookItem> Items { get; private set; } = new List<LookItem>();
        public void Equip(LookItem newItem)
        {
            RemoveEqualInTypeItem(newItem);
            RemoveConflictingItems(newItem);
            Items.Add(newItem);
        }

        public bool IsEquipped(LookItem newItem)
        {
            return Items.Any(i => i.IsHasEqualPropertiesId(newItem.PropertiesId));
        }

        private void RemoveEqualInTypeItem(LookItem newItem)
        {
            var existedItem = Items.Find(li => li.IsEqualInTypeWithItem(newItem));
            if (null != existedItem)
                Items.Remove(existedItem);
        }

        private void RemoveConflictingItems(LookItem newItem)
        {
            var conflictingItems = Items.Where(
                i => newItem.Type.GetConflictingType().Contains(i.Type));
            
            Items.RemoveAll(i => conflictingItems.Contains(i));
        }

        private void SolveHidings()
        {
            foreach (var item in Items)
            {
                var itemHidingTypes = item.Type.GetItemHidingTypes();
                item.SetHiding(Items.Any(i => itemHidingTypes.Contains(i.Type)));
            }
        }
    }
}