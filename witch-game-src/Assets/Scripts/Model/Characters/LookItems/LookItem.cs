namespace Model.Characters.LookItems
{
    public class LookItem
    {
        public string PropertiesId { get; private set; }
        public LookItemType Type { get; private set; }
        public bool IsHidden { get; private set;  }

        public LookItem()
        {
        }

        public LookItem(LookItemType type, string propertiesId)
        {
            Type = type;
            PropertiesId = propertiesId;
        }
        
        public bool IsEqualInTypeWithItem(LookItem compareItem)
        {
            return Equals(Type, compareItem.Type);
        }
        
        public bool IsHasEqualPropertiesId(string propertiesId)
        {
            return PropertiesId == propertiesId;
        }

        public void SetHiding(bool isHidden)
        {
            IsHidden = isHidden;
        }
    }
}