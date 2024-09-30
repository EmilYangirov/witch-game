using Cysharp.Threading.Tasks;
using Infrastructure.Installers;
using Infrastructure.SceneManagement;
using UnityEngine;

namespace Infrastructure.EntryPoints
{
    public class MainGameplayEntryPoint : MonoBehaviour, ISceneEntryPoint
    {
        public UniTask RunAsync()
        {
            var lifetimeScope = this.GetComponent<ServiceInstaller>();
            lifetimeScope.Build();
            var bindingsInstaller = this.GetComponent<MainGameplayBindingsInstaller>();
            bindingsInstaller.CreateBindings();
            return UniTask.CompletedTask;
        }

    }
}