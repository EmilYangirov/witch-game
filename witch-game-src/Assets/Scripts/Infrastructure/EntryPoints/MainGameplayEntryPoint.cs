using Cysharp.Threading.Tasks;
using Infrastructure.SceneManagement;
using UnityEngine;

namespace Infrastructure.EntryPoints
{
    public class MainGameplayEntryPoint : MonoBehaviour, ISceneEntryPoint
    {
        public UniTask RunAsync()
        {
            return UniTask.CompletedTask;
        }
    }
}