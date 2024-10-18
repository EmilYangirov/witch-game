using System.Collections.Generic;
using System.Linq;
using Model.Characters;
using Model.Characters.LookItems;
using Model.ScriptableObjects;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface ICharacterFactory
    {
        public Character CreateCharacter();
    }
    
    public class CharacterFactory : ICharacterFactory
    {
        private List<LookItemProperties> _defaultItems = new();

        public CharacterFactory()
        {
            _defaultItems = Resources.LoadAll<LookItemProperties>("ScriptableObjects/LookItems")
                .Where(i => i.IsDefault == true).ToList();
        }

        public Character CreateCharacter()
        {
            var character = new Character();
            
            foreach (var item in _defaultItems)
            {
                var newItem = new LookItem(item.Type, item.Id);
                character.EquipItem(newItem);
            }

            return character;
        }
    }
}