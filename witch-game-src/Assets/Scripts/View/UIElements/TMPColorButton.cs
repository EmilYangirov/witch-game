using SharedKernel.View.UIElements;
using TMPro;
using UnityEngine;

namespace View.UIElements
{
    public class TMPColorButton : BaseButton
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Color _disableColor;
        [SerializeField] private Color _enableColor;
        protected override void OnClick()
        {
            throw new System.NotImplementedException();
        }

        public override void Disable()
        {
            throw new System.NotImplementedException();
        }
    }
}