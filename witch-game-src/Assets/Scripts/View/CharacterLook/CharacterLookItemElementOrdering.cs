using UnityEngine;

namespace View.CharacterLook
{
    public abstract class CharacterLookItemElementOrdering : MonoBehaviour
    {
        [SerializeField] protected bool _isBackground;
        public abstract void SetLookItemElementOrdering(int order);
    }
}