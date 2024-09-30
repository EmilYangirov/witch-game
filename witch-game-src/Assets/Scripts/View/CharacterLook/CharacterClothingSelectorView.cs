using System.Collections.Generic;
using Model.Characters.CharacterLooks;
using MVVM;
using SharedKernel.View.Base;
using SharedKernel.View.UIElements;

namespace View.CharacterLook
{
    public class CharacterClothingSelectorView : BaseView
    {
        [Data("ShowItemsButton")] 
        public BaseButton ShowElementsGroupButton;
        
        [Data("Items")] 
        public List<ClothingItem> Items;
    }
}