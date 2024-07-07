using System.Collections.Generic;
using Model.Character.CharacterLook.Interfaces;

namespace Model.Character.CharacterLook
{
    public class CharacterLook : ICharacterLook
    {
        private readonly ClothingCollection _clothing = new();
        private readonly AppearanceCollection _appearance = new();
        
        public void ChangeClothes(ClothingItem newItem)
        {
            _clothing.AddItem(newItem);
        }

        public void ChangeAppearance(AppearanceItem newItem)
        {
            _appearance.AddItem(newItem);
        }

        public List<ClothingItem> GetClothes()
        {
            return _clothing.Items;
        }

        public List<AppearanceItem> GetAppearance()
        {
            return _appearance.Items;
        }
    }
}