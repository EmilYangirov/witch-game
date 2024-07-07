namespace Model.Character.CharacterLook
{
    public class AppearanceCollection : CharacterItemCollection<AppearanceItem>
    {
        public override void AddItem(AppearanceItem newItem)
        {
            SwitchItemWithEqualType(newItem);
        }
    }
}