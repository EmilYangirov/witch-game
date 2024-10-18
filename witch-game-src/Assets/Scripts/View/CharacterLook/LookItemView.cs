using Model.ScriptableObjects;
using MVVM;
using SharedKernel.View.Base;
using UnityEngine;

namespace View.CharacterLook
{
    public class LookItemView : BaseView
    {
        [Data("Properties")]
        public LookItemProperties Properties;

        private GameObject _spritesGo;

        private void OnValidate()
        {
            _spritesGo = transform.GetChild(0).gameObject;
        }

        [Method("OnEquipStatusChange")]
        public void OnEquipStatusChange(bool isEquipped)
        {
            if (isEquipped)
            {
                Equip();
            }
            else
            {
                TakeOff();
            }
        }

        private void Equip()
        {
            _spritesGo.SetActive(true);
        }
        
        private void TakeOff()
        {
            _spritesGo.SetActive(false);
        }
    }
}