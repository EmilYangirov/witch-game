using System.Threading;
using Cysharp.Threading.Tasks;

namespace Model.Characters
{
    public interface ICharacterRepository
    {
        public UniTask<Character> GetCharacterAsync(string key, CancellationToken cancellationToken);
        public UniTask UpdateCharacterAsync(Characters.Character character, string key, CancellationToken cancellationToken);
    }
}