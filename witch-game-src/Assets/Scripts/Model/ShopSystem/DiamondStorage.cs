using SharedKernel.Model.ShopSystem;

namespace Model.ShopSystem
{
    public class DiamondStorage : MoneyStorage
    {
        public DiamondStorage(IDiamondRepository repository) : base(repository)
        {
        }
    }
}