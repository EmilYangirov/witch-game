using System.Threading;
using Cysharp.Threading.Tasks;

namespace Model.Characters
{
    public interface ICharacterRepository
    {
        public UniTask<Character> GetCharacterAsync(CancellationToken cancellationToken);
        public UniTask UpdateMainCharacterAsync(Character character, CancellationToken cancellationToken);
    }
}