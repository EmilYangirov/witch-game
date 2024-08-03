using Cysharp.Threading.Tasks;

namespace Infrastructure.SceneManagement
{
    public interface ISceneManagementService
    {
        public UniTask LoadInitialSceneAsync();
    }
}