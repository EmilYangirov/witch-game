using Model.ShopSystem;
using SharedKernel.ViewModel.ShopSystem;

namespace ViewModels
{
    public class DiamondsViewModel : MoneyViewModel<DiamondStorage>
    {
        public DiamondsViewModel(DiamondStorage moneyStorage) : base(moneyStorage)
        {
        }
    }
}