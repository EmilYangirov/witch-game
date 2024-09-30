using UnityEngine;

namespace View.CharacterLook
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class CharacterClothingElementInteraction : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private bool _isCanBePartitialHiddenUnderClothes;
        [SerializeField] private bool _isCanBeHiddenUnderClothes;
        
        private void OnValidate()
        {
            this.TryGetComponent(out _renderer);
        }
        
        public void SetMaskVisibility(ClothingInteractionType interactionType)
        {
            _renderer.maskInteraction = interactionType switch
            {
                (ClothingInteractionType.NotInteract) => SpriteMaskInteraction.None,
                (ClothingInteractionType.Hidden) => _isCanBeHiddenUnderClothes
                    ? SpriteMaskInteraction.VisibleInsideMask
                    : SpriteMaskInteraction.None,
                (ClothingInteractionType.TuckedIn) => _isCanBePartitialHiddenUnderClothes
                    ? SpriteMaskInteraction.VisibleInsideMask
                    : SpriteMaskInteraction.None,
                _ => SpriteMaskInteraction.None
            };
        }
    }
}