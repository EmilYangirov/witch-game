namespace Model.Characters.CharacterLooks
{
    public class AppearanceItem : ILookItem
    {
        public string Type { get; set; }
        public bool IsEqualInTypeWithItem(ILookItem compareItem)
        {
            return Type == compareItem.Type;
        }
    }
}