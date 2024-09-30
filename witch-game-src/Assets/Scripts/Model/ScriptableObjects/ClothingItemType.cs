using System.Collections.Generic;
using UnityEngine;

namespace Model.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ClothingItemType")]
    public class ClothingItemType : ScriptableObject
    {
        public string Name;
        public List<ClothingItemType> ConflictTypes;
        public List<ClothingItemType> AheadTypes;
    }
}