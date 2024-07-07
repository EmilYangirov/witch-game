namespace Model.Character.CharacterLook.Interfaces
{
    public interface ILookItem
    {
        public bool IsEqualInTypeWithItem(ILookItem compareItem);
        public string Type { get;  }
    }
}