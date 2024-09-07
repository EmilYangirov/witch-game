namespace Model.Characters.CharacterLooks
{
    public interface ILookItem
    {
        public bool IsEqualInTypeWithItem(ILookItem compareItem);
        public string Type { get;  }
    }
}