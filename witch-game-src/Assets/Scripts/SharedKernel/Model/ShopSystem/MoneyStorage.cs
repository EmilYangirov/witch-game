using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace SharedKernel.Model.ShopSystem
{
    public class MoneyStorage
    {
        public event Action<int> OnStateChanged;
        public int Value { get; private set; } = 0;
        
        private readonly IMoneyRepository _repository;

        public MoneyStorage(IMoneyRepository repository)
        {
            _repository = repository;
        }

        public async UniTask InitializeData(CancellationToken cancellationToken)
        {
            var value = await _repository.GetAsync(cancellationToken);
            SpendMoneys(value);
        }

        public async UniTask SaveData(CancellationToken cancellationToken)
        {
            await _repository.SaveAsync(Value, cancellationToken);
        }
        
        public void SpendMoneys(int value)
        {
            if (!IsMoneysEnough(value))
                return;

            Value -= value;
            this.OnStateChanged?.Invoke(this.Value);
        }

        public void AddMoneys(int value)
        {
            Value += value;
            this.OnStateChanged?.Invoke(this.Value);
        }
        public bool IsMoneysEnough(int value)
        {
            return Value >= value;
        }
    }
}