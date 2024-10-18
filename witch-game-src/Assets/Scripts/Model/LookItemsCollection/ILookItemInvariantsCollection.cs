using System.Collections.Generic;
using Model.Characters.LookItems;
using Model.ScriptableObjects;

namespace Model.LookItemsCollection
{
    public interface ILookItemInvariantsCollection
    {
        public List<(LookItem,LookItemProperties)> GetLookItemPropertiesList();
        public void AddLookItemProperties(LookItemProperties item);
        public bool IsItemExists(LookItemProperties item);
        public (LookItem item, LookItemProperties properties)? GetLookItemByPropertiesId(string id);
    }
}