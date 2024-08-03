using Cysharp.Threading.Tasks;
using Infrastructure.SceneManagement;
using UnityEngine;

namespace Infrastructure.EntryPoints
{
    public class GameEntryPoint
    {
        private static GameEntryPoint _instance;
        private ISceneManagementService _sceneManagementService;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Main()
        {
            _instance = new();
            _ = _instance.RunGameAsync();
        }
        private async UniTask RunGameAsync()
        {
            _sceneManagementService = InitSceneManagementService();
            await _sceneManagementService.LoadInitialSceneAsync();
        }

        private ISceneManagementService InitSceneManagementService()
        {
            return new SceneManagementService();
        }
    }
}

