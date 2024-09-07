namespace Model.Characters.CharacterLooks
{
    public class ClothingCollection : CharacterItemCollection<ClothingItem>
    {
        public override void AddItem(ClothingItem newItem)
        {
            RemoveConflictingClothesWithItem(newItem);
            SwitchItemWithEqualType(newItem);
        }
        private void RemoveConflictingClothesWithItem(ClothingItem newItem)
        {
            Items.RemoveAll(newItem.IsConflictWithItem);
        }
    }
}