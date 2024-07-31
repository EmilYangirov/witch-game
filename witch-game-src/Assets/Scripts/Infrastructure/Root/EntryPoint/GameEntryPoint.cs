using Infrastructure.Utils;
using UnityEngine;

namespace Infrastructure.Root.EntryPoint
{
    public class GameEntryPoint
    {
        private static GameEntryPoint _instance;
        private readonly Coroutines _coroutines;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Main()
        {
            _instance = new();
            _instance.RunGame();
        }
        private GameEntryPoint()
        {
            _coroutines = CreateCoroutines();
        }
        private Coroutines CreateCoroutines()
        {
            return new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutines);
        }
        private void RunGame()
        {
            
        }
    }
}

