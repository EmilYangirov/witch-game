using System.Threading;
using Cysharp.Threading.Tasks;

namespace SharedKernel.Infrastructure.SaveSystem
{
    public interface ISaveSystem
    {
        public UniTask SaveAsync(string key, object data, CancellationToken cancellationToken);
        public UniTask<T> LoadAsync<T>(string key, CancellationToken cancellationToken);
    }
}