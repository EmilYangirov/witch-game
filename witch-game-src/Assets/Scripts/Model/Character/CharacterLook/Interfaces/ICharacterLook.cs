using System.Collections.Generic;

namespace Model.Character.CharacterLook.Interfaces
{
    public interface ICharacterLook
    {
        public void ChangeClothes(ClothingItem newItem);
        public void ChangeAppearance(AppearanceItem newItem);
        public List<ClothingItem> GetClothes();
        public List<AppearanceItem> GetAppearance();
    }
}