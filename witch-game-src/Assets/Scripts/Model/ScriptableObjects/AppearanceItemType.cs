using UnityEngine;

namespace Model.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AppearanceItemType")]
    public class AppearanceItemType : ScriptableObject
    {
        public string Name;
    }
}