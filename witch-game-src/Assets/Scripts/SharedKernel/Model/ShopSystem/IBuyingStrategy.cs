namespace SharedKernel.Model.ShopSystem
{
    public interface IBuyingStrategy
    {
        public void BuyItem(IShopItem item, out bool isBought);
        public bool IsCanBuyItem(IShopItem item);
        public string GetKey();
    }
}