using Model.ShopSystem;
using SharedKernel.ViewModel.ShopSystem;

namespace ViewModels
{
    public class GoldViewModel : MoneyViewModel<GoldStorage>
    {
        public GoldViewModel(GoldStorage moneyStorage) : base(moneyStorage)
        {
        }
    }
}