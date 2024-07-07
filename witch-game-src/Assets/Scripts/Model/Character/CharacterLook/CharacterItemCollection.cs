using System.Collections.Generic;
using Model.Character.CharacterLook.Interfaces;

namespace Model.Character.CharacterLook
{ 
    public abstract class CharacterItemCollection<T> where T : ILookItem
    {
        public List<T> Items { get; private set; }
        public abstract void AddItem(T newItem);
        protected void SwitchItemWithEqualType(T newItem)
        {
            var existedItem = Items.Find(li => li.IsEqualInTypeWithItem(newItem));
            if (null != existedItem)
                Items.Remove(existedItem);
            
            Items.Add(newItem);
        }
    }
}