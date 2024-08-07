using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ClothingItemType")]
    public class ClothingItemType : ScriptableObject
    {
        public string Name;
        public List<ClothingItemType> ConflictTypes;
        public int OrderInLayer;
    }
}