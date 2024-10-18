using Cysharp.Threading.Tasks;
using Infrastructure.EntryPoints;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.SceneManagement
{
    public class SceneManagementService : ISceneManagementService
    {
        private readonly UIRootView _uiRootView;

        public SceneManagementService()
        {
            _uiRootView = InitUiRootView();
        }

        public async UniTask LoadInitialSceneAsync()
        {
            var sceneName = SceneNaming.MainGameplay;

            #region UnityEditor Mode
            if (Application.isEditor)
            {
                sceneName = SceneManager.GetActiveScene().name;

                switch (sceneName)
                {
                    case SceneNaming.MainGameplay:
                        await LoadSceneAsync<MainGameplayEntryPoint>(sceneName);
                        return;
                    case SceneNaming.StoryGameplay:
                        await LoadSceneAsync<StoryGameplayEntryPoint>(sceneName);
                        return;
                    default:
                        await LoadSceneAsync<MainGameplayEntryPoint>(SceneNaming.MainGameplay);
                        return;
                }
            }
            #endregion

            await LoadSceneAsync<MainGameplayEntryPoint>(sceneName);
        }
        
        private async UniTask LoadSceneAsync<T>(string sceneName) where T : Object, ISceneEntryPoint
        {
            _uiRootView.ShowLoadingScreen();
            await SceneManager.LoadSceneAsync(SceneNaming.Bootstrap);
            await SceneManager.LoadSceneAsync(sceneName);
            var sceneEntryPoint = Object.FindFirstObjectByType<T>();
            await sceneEntryPoint.RunAsync();
            _uiRootView.HideLoadingScreen();
        }
        
        private UIRootView InitUiRootView()
        {
            var prefab = Resources.Load<UIRootView>("UI/UiRootView");
            var newUiRootView = Object.Instantiate(prefab);
            Object.DontDestroyOnLoad(newUiRootView.gameObject);
            return newUiRootView;
        }
    }
}