using SharedKernel.Model.ShopSystem;

namespace Model.ShopSystem
{
    public class GoldStorage : MoneyStorage
    {
        public GoldStorage(IGoldRepository repository) : base(repository)
        {
        }
    }
}