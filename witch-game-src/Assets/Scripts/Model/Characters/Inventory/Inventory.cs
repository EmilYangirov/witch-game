using System.Collections.Generic;
using System.Linq;
using Model.Characters.LookItems;

namespace Model.Characters.Inventory
{
    public class CharacterInventory
    {
        public List<LookItem> AvailableLookItems { get; private set; } = new();

        public bool IsLookItemInInventory(string propertyId)
        {
            return AvailableLookItems.Any(li => li.PropertiesId.Equals(propertyId));
        }

        public void AddLookItem(LookItem item)
        {
            AvailableLookItems.Add(item);
        }
    }
}