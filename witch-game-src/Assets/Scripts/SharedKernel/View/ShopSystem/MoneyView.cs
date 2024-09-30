using MVVM;
using SharedKernel.View.Base;
using TMPro;

namespace SharedKernel.View.ShopSystem
{
    public class MoneyView : BaseView
    {
        [Data("Money")]
        public TMP_Text Value;
    }
}