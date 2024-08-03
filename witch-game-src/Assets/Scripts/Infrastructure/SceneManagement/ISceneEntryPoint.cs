using Cysharp.Threading.Tasks;

namespace Infrastructure.SceneManagement
{
    public interface ISceneEntryPoint
    {
        public UniTask RunAsync();
    }
}