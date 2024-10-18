using System.Collections.Generic;
using System.Linq;
using Model.Characters.LookItems;
using Model.ScriptableObjects;

namespace Model.LookItemsCollection
{
    public class LookItemInvariantsCollection : ILookItemInvariantsCollection
    {
        private List<(LookItem item, LookItemProperties properties)> _items = new();
            
        public List<(LookItem, LookItemProperties)> GetLookItemPropertiesList()
        {
            return _items;
        }

        public bool IsItemExists(LookItemProperties item)
        {
            return _items.Any(i => i.properties.Id == item.Id);
        }

        public (LookItem item, LookItemProperties properties)? GetLookItemByPropertiesId(string id)
        {
            return _items.FirstOrDefault(i => i.properties.Id == id);
        }

        public void AddLookItemProperties(LookItemProperties item)
        {
            if (IsItemExists(item))
                return; 
            
            _items.Add((new LookItem(item.Type, item.Id), item));
        }
    }
}