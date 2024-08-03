using System;
using UnityEngine;

namespace Infrastructure.SceneManagement
{
    public class UIRootView : MonoBehaviour, IUiRootView
    {
        [SerializeField] private GameObject _loadingScreen;

        private void Awake()
        {
            HideLoadingScreen();
        }

        public void ShowLoadingScreen()
        {
            if (null == _loadingScreen)
                throw new NullReferenceException(nameof(_loadingScreen));
            
            _loadingScreen.SetActive(true);
        }

        public void HideLoadingScreen()
        {
            if (null == _loadingScreen)
                throw new NullReferenceException(nameof(_loadingScreen));
            
            _loadingScreen.SetActive(false);
        }
    }
}