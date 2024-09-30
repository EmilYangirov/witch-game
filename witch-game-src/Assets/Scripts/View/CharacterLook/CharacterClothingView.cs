using Model.ScriptableObjects;
using UnityEngine;

namespace View.CharacterLook
{
    public class CharacterClothingView : MonoBehaviour
    {
        [SerializeField] private ClothingItemProperties Properties;
        [SerializeField] private CharacterLookItemElementOrdering[] _orderings;
        [SerializeField] private CharacterClothingElementInteraction[] _interactions;
        private void OnValidate()
        {
            _orderings = this.GetComponentsInChildren<CharacterLookItemElementOrdering>();
            _interactions = this.GetComponentsInChildren<CharacterClothingElementInteraction>();
        }

        public void SetOrderingInLayer(int order)
        {
            foreach (var element in _orderings)
            {
                element.SetLookItemElementOrdering(order);
            }
        }

        public void SolveClothingVisibility(ClothingInteractionType interactionType)
        {
            foreach (var element in _interactions)
            {
                element.SetMaskVisibility(interactionType);
            }
        }
    }
}

