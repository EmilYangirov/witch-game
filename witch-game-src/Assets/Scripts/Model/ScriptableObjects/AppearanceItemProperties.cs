using Model.ShopSystem;
using UnityEngine;

namespace Model.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AppearanceItem")]
    public class AppearanceItemProperties : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
        public AppearanceItemProperties Type;
        public string Description;
        public int Price;
        public CurrencyType RequiredCurrencyType;
    }
}