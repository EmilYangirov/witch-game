using Model.ShopSystem;
using UnityEngine;

namespace Model.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuyingStrategyProperties")]
    public class BuyingStrategyProperties : ScriptableObject
    {
        public BuyingStrategyType StartegyType;
        public Sprite Icon;
    }
}