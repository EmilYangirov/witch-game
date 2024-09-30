using System.Collections.Generic;

namespace SharedKernel.Model.ShopSystem
{
    public class Shop : IShop
    {
        private readonly Dictionary<string, IBuyingStrategy> _strategies;

        public Shop(List<IBuyingStrategy> strategies)
        {
            foreach (var strategy in strategies)
            {
                RegisterStrategy(strategy);
            }
        }

        public void Buy(string strategyKey, IShopItem itemToBuy, out bool isBought)
        {
            if(!_strategies.TryGetValue(strategyKey, out var strategy))
            {
                isBought = false;
                return;
            }
            
            strategy.BuyItem(itemToBuy, out isBought);
        }

        public void RegisterStrategy(IBuyingStrategy strategy)
        {
            if (_strategies.ContainsKey(strategy.GetKey()))
                return;
            
            _strategies.Add(strategy.GetKey(), strategy);
        }
    }
}