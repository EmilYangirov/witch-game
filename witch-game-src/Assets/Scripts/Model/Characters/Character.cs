using System;
using System.Collections.Generic;
using Model.Characters.CharacterLookCollections;
using Model.Characters.Inventory;
using Model.Characters.LookItems;

namespace Model.Characters
{
    public class Character : ICharacter
    {
        public Appearance Appearance { get; private set; } = new();
        public Clothing Clothing { get; private set; } = new();
        public List<Clothing> ClothingSets { get; private set; } = new();
        public CharacterInventory Inventory { get; private set; } = new();
        public Action OnCurrentLookChanged { get; set; }
        public Character()
        {
           
        }

        public void SwitchClothing()
        {
            var countOfCloths = ClothingSets.Count;
            var newClothingOrder = Clothing.OrderNumber++ > countOfCloths
                ? Clothing.OrderNumber++
                : 1;

            Clothing = ClothingSets.Find(s => s.OrderNumber == newClothingOrder);
            OnCurrentLookChanged?.Invoke();
        }

        public bool IsItemEquipped(LookItem item)
        {
            return item.Type.GetCategory().Equals(LookItemCategory.Clothing) 
                ? Clothing.IsEquipped(item) 
                : Appearance.IsEquipped(item);
        }

        public void EquipItem(LookItem item)
        {
            if (item.Type.GetCategory().Equals(LookItemCategory.Clothing) )
                Clothing.Equip(item);
            else
                Appearance.Equip(item);
            
            OnCurrentLookChanged?.Invoke();
        }

        public bool IsNeedDefaultLook()
        {
            return Appearance.Items.Count == 0 && Clothing.Items.Count == 0;
        }
    }
}