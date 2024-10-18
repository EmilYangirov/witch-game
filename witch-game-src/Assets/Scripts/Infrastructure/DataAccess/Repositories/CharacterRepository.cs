using System.Threading;
using Cysharp.Threading.Tasks;
using Infrastructure.Services;
using Model.Characters;
using SharedKernel.Infrastructure.SaveSystem;

namespace Infrastructure.DataAccess.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ICharacterFactory _characterFactory;
        private readonly ISaveSystem _saveSystem;
        private const string MainCharacterKey = "MainCharacter";
        private Character _mainCharacter;

        public CharacterRepository(ISaveSystem saveSystem, ICharacterFactory characterFactory)
        {
            _saveSystem = saveSystem;
            _characterFactory = characterFactory;
        }

        private async void InitMainCharacter()
        {
            var token = new CancellationTokenSource();
            var result = await GetCharacterAsync(token.Token);
            _mainCharacter = result;
        }

        public async UniTask<Character> GetCharacterAsync(CancellationToken cancellationToken)
        {
            var result = await _saveSystem.LoadAsync<Character>(MainCharacterKey, cancellationToken);
            return result ?? _characterFactory.CreateCharacter();
        }

        public async UniTask UpdateMainCharacterAsync(Character character, CancellationToken cancellationToken)
        {
            await _saveSystem.SaveAsync(MainCharacterKey, character, cancellationToken);
        }
    }
}