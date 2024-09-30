using System.Threading;
using Cysharp.Threading.Tasks;
using Model.Characters;
using SharedKernel.Infrastructure.SaveSystem;

namespace Infrastructure.DataAccess.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ISaveSystem _saveSystem;
        private const string Key = "Character";
        public CharacterRepository(ISaveSystem saveSystem)
        {
            _saveSystem = saveSystem;
        }

        public async UniTask<Character?> GetCharacterAsync(CancellationToken cancellationToken)
        {
            var result = await _saveSystem.LoadAsync<Character>(Key, cancellationToken);
            return result;
        }

        public async UniTask UpdateCharacterAsync(Character character, CancellationToken cancellationToken)
        {
            await _saveSystem.SaveAsync(Key, character, cancellationToken);
        }
    }
}