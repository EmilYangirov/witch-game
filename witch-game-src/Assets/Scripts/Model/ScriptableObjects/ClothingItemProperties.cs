using Model.ShopSystem;
using UnityEngine;

namespace Model.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ClothingItem")]
    public class ClothingItemProperties : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
        public ClothingItemType Type;
        public string Description;
        public int Price;
        public CurrencyType RequiredCurrencyType;
    }
}