using System.Threading;
using Cysharp.Threading.Tasks;
using Model.Characters;
using SharedKernel.Infrastructure.SaveSystem;
using UnityEngine;

namespace Infrastructure.DataAccess.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ISaveSystem _saveSystem;

        public CharacterRepository(ISaveSystem saveSystem)
        {
            _saveSystem = saveSystem;
        }

        public async UniTask<Character> GetCharacterAsync(string key, CancellationToken cancellationToken)
        {
            var result = await _saveSystem.LoadAsync<Character>(key, cancellationToken);
            return result;
        }

        public async UniTask UpdateCharacterAsync(Character character, string key, CancellationToken cancellationToken)
        {
            await _saveSystem.SaveAsync(key, character, cancellationToken);
            Debug.Log("Character data saved successfully");
        }
    }
}