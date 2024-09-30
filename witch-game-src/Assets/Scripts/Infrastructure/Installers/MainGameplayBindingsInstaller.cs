using System;
using System.Collections.Generic;
using System.Linq;
using MVVM;
using SharedKernel.View.Base;
using UnityEditor;
using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;

namespace Infrastructure.Installers
{
    public class MainGameplayBindingsInstaller : MonoBehaviour
    {
        [Inject]
        public IObjectResolver diContainer;
        [SerializeField] private List<MvvmCompliance> _mvvmCompliances;
        
        public void OnValidate()
        {
            var views = FindObjectsByType<BaseView>(FindObjectsInactive.Include, FindObjectsSortMode.None);

            foreach (var item in views)
            {
                if(_mvvmCompliances.Any(e => e.IsSameWith(item)))
                    continue;
                
                _mvvmCompliances.Add(new MvvmCompliance(item));
            }
        }
        
        public void CreateBindings()
        {
            foreach (var item in _mvvmCompliances)
            {
                object view = item.View;
                object model = this.diContainer.Resolve(item.ViewModel.GetClass())
                               ?? throw new Exception($"Binding type of view {item.ViewModel} is not found!");

                var binder = BinderFactory.CreateComposite(view, model);
                binder.Bind();
            }
        }
    }
    
    [System.Serializable]
    public class MvvmCompliance
    {
        [SerializeField]
        public Object View;
        public MonoScript ViewModel;

        public MvvmCompliance(Object view)
        {
            View = view;
        }

        public bool IsSameWith(Object compareView)
        {
            return compareView.Equals(View);
        }
    }
}