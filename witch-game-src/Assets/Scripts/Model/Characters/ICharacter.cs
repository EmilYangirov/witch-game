using System;
using Model.Characters.LookItems;

namespace Model.Characters
{
    public interface ICharacter
    {
        public Action OnCurrentLookChanged { get; set; }
        public void SwitchClothing();
        public bool IsItemEquipped(LookItem item);
        public void EquipItem(LookItem item);
        public bool IsNeedDefaultLook();
    }
}