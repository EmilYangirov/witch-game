namespace SharedKernel.Model.ShopSystem
{
    public interface IShop
    {
        public void Buy(string strategyKey, IShopItem itemToBuy, out bool isBought);
        public void RegisterStrategy(IBuyingStrategy strategy);
    }
}