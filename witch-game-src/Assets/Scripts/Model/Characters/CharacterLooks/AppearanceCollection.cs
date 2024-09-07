namespace Model.Characters.CharacterLooks
{
    public class AppearanceCollection : CharacterItemCollection<AppearanceItem>
    {
        public override void AddItem(AppearanceItem newItem)
        {
            SwitchItemWithEqualType(newItem);
        }
    }
}