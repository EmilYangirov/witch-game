using System.IO;
using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace SharedKernel.Infrastructure.SaveSystem
{
    public class JsonSaveSystem : ISaveSystem
    {
        public async UniTask SaveAsync(string key, object data, CancellationToken cancellationToken)
        {
            var path = CreatePath(key);
            var json = JsonConvert.SerializeObject(data);

            using (var stream = new StreamWriter(path))
            {
                await stream.WriteAsync(json);
            }
        }

        public async UniTask<T?> LoadAsync<T>(string key, CancellationToken cancellationToken)
        {
            var path = CreatePath(key);
            using (var reader = new StreamReader(path))
            {
                var json = await reader.ReadToEndAsync();
                var data = JsonConvert.DeserializeObject<T>(json);
                return data;
            };
        }
        private string CreatePath(string key)
        {
            return Path.Combine(Application.persistentDataPath, key);
        }
    }
}