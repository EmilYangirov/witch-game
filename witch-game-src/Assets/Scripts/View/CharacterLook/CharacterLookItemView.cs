using UnityEngine;

namespace View.CharacterLook
{
    public class CharacterLookItemView : MonoBehaviour
    {
        [SerializeField] private CharacterLookItemElementView[] _elements;

        private void OnValidate()
        {
            _elements = this.GetComponentsInChildren<CharacterLookItemElementView>();
        }
    }
}

