using System.Threading;
using Cysharp.Threading.Tasks;

namespace SharedKernel.Model.ShopSystem
{
    public interface IMoneyRepository
    {
        public UniTask<int> GetAsync(CancellationToken cancellationToken);
        public UniTask SaveAsync(int value, CancellationToken cancellationToken);
    }
}