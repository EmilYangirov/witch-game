using JetBrains.Annotations;
using Model.Characters.LookItems;
using SharedKernel.Inspector;
using SharedKernel.ScriptableObjects;
using UnityEngine;

namespace Model.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LookItemProperties")]
    public class LookItemProperties : ScriptableObject
    {
        [ScriptableObjectId]
        public string Id;
        public string Name;
        public Sprite Icon;
        public LookItemType Type;
        public bool IsDefault;
        public bool IsPurchasable;
        
        [ConditionalProperty("IsPurchasable")] 
        [CanBeNull]
        public AvailableBuyingStrategy BuyingStrategy;
        
        [ConditionalProperty("IsPurchasable")]
        public bool CanBeEquippedByAds;
    }
    
    [System.Serializable]
    public class AvailableBuyingStrategy
    {
        public BuyingStrategyProperties Properties;
        public int Price;
    }
}