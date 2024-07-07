using UnityEngine;

namespace Infrastructure.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AppearanceItemType")]
    public class AppearanceItemType : ScriptableObject
    {
        public string Name { get; set; }
        public int OrderInLayer { get; private set; }
    }
}