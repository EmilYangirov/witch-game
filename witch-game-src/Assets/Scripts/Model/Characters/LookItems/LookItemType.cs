using System.Collections.Generic;

namespace Model.Characters.LookItems
{
    public enum LookItemType
    {
        Face = 1,
        Hair = 2,
        Hat = 3,
        Boots = 4,
        Shirt = 5,
        Skirt = 6,
        Suit = 7,
        Jacket = 8,
    }
    public static class LookItemTypeExtensions
    {
        public static List<LookItemType> GetConflictingType(this LookItemType item)
        {
            return true switch
            {
                _ when item.Equals(LookItemType.Suit) => new List<LookItemType>()
                {
                    LookItemType.Shirt,
                    LookItemType.Skirt,
                    LookItemType.Jacket,
                },
                _ when item.Equals(LookItemType.Skirt) => new List<LookItemType>()
                {
                    LookItemType.Suit,
                },
                _ when item.Equals(LookItemType.Shirt) => new List<LookItemType>()
                {
                    LookItemType.Suit,
                },
                _ => new List<LookItemType>()
            };
        }

        public static List<LookItemType> GetItemHidingTypes(this LookItemType item)
        {
            return true switch
            {
                _ when item.Equals(LookItemType.Shirt) => new List<LookItemType>()
                {
                    LookItemType.Jacket,
                },
                _ => new List<LookItemType>()
            };
        }

        public static LookItemCategory GetCategory(this LookItemType item)
        {
            return item switch
            {
                LookItemType.Boots => LookItemCategory.Clothing,
                LookItemType.Face => LookItemCategory.Appearance,
                LookItemType.Hair => LookItemCategory.Appearance,
                LookItemType.Hat => LookItemCategory.Clothing,
                LookItemType.Jacket => LookItemCategory.Clothing,
                LookItemType.Shirt => LookItemCategory.Clothing,
                LookItemType.Skirt => LookItemCategory.Clothing,
                LookItemType.Suit => LookItemCategory.Clothing,
                _ => LookItemCategory.Appearance
            };
        }
    }
}