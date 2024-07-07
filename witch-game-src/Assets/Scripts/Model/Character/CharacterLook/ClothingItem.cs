using System.Collections.Generic;
using Model.Character.CharacterLook.Interfaces;

namespace Model.Character.CharacterLook
{
    public class ClothingItem : ILookItem
    {
        public string Type { get; private set; }
        public List<string> ConflictingTypes { get; private set; }
        public int Order { get; private set; }
        public bool IsConflictWithItem(ClothingItem compareItem)
        {
            return this.ConflictingTypes.Contains(compareItem.Type);
        }
        public bool IsEqualInTypeWithItem(ILookItem compareItem)
        {
            return Type == compareItem.Type;
        }
    }
}