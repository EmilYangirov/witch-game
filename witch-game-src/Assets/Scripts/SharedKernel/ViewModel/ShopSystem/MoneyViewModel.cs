using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using MVVM;
using R3;
using SharedKernel.Model.ShopSystem;
using VContainer.Unity;

namespace SharedKernel.ViewModel.ShopSystem
{
    public class MoneyViewModel<T> : IInitializable, IDisposable where T : MoneyStorage 
    {
        [Data("Money")]
        public ReactiveProperty<string> Money = new();
        
        private readonly T _moneyStorage;
        public MoneyViewModel(T moneyStorage)
        {
            this._moneyStorage = moneyStorage;
            Initialize();
        }

        public void Dispose()
        {
            Money?.Dispose();
            _moneyStorage.OnStateChanged -= this.OnMoneyChanged;
        }

        public async void Initialize()
        {
            _moneyStorage.OnStateChanged += this.OnMoneyChanged;
            await InitializeData();
        }

        private async UniTask InitializeData()
        {
            var ct = new CancellationTokenSource();
            await _moneyStorage.InitializeData(ct.Token);
        }

        private void OnMoneyChanged(int money)
        {
            Money.Value = money.ToString();
        }
    }
}