namespace Model.Characters.CharacterLooks
{
    public class CharacterLook
    {
        public ClothingCollection Clothing { get; private set; }
        public AppearanceCollection Appearance { get; private set; }
        
        public void ChangeClothes(ClothingItem newItem)
        {
            Clothing.AddItem(newItem);
        }

        public void ChangeAppearance(AppearanceItem newItem)
        {
            Appearance.AddItem(newItem);
        }
    }
}