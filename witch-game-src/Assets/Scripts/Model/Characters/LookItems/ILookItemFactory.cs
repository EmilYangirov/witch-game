using System.Collections.Generic;

namespace Model.Characters.LookItems
{
    public interface ILookItemFactory
    {
        public List<LookItem> CreateDefaultValues();
        public LookItem CreateLookItem();
    }
}