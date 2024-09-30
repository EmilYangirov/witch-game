using System.Threading;
using Cysharp.Threading.Tasks;
using Model.ShopSystem;
using SharedKernel.Infrastructure.SaveSystem;

namespace Infrastructure.DataAccess.Repositories
{
    public class DiamondRepository : IDiamondRepository
    {
        private readonly ISaveSystem _saveSystem;
        private const string Key = "Diamond";

        public DiamondRepository(ISaveSystem saveSystem)
        {
            _saveSystem = saveSystem;
        }

        public async UniTask<int> GetAsync(CancellationToken cancellationToken)
        {
            var result = await _saveSystem.LoadAsync<int>(Key, cancellationToken);
            return result;
        }

        public async UniTask SaveAsync(int value, CancellationToken cancellationToken)
        {
            await _saveSystem.SaveAsync(Key, value, cancellationToken);
        }
    }
}