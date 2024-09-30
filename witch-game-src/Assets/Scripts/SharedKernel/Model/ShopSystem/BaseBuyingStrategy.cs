namespace SharedKernel.Model.ShopSystem
{
    public abstract class BaseBuyingStrategy : IBuyingStrategy
    {
        private readonly MoneyStorage _moneyStorage;
        public BaseBuyingStrategy(MoneyStorage moneyStorage)
        {
            _moneyStorage = moneyStorage;
        }
        
        public void BuyItem(IShopItem item, out bool isBought)
        {
            if(IsCanBuyItem(item))
            {
                isBought = false;
                return;
            }
            
            _moneyStorage.SpendMoneys(item.Price);
            isBought = true;
        }

        public bool IsCanBuyItem(IShopItem item)
        {
            return _moneyStorage.IsMoneysEnough(item.Price);
        }

        public abstract string GetKey();
    }
}