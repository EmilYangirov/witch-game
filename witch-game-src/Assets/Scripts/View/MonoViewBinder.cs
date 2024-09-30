using System;
using MVVM;
using UnityEditor;
using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;

namespace View
{
    public sealed class MonoViewBinder : MonoBehaviour
    {
        private enum BindingMode
        {
            FromInstance = 0,
            FromResolve = 1,
            FromResolveId = 2
        }

        [SerializeField]
        private BindingMode viewBinding;

        [SerializeField]
        private Object view;

        [SerializeField]
        private MonoScript viewType;

        [SerializeField]
        private string viewId;

        [Space(8)]
        [SerializeField]
        private BindingMode viewModelBinding;

        [SerializeField]
        private Object viewModel;

        [SerializeField]
        private MonoScript viewModelType;

        [SerializeField]
        private string viewModelId;

        [Inject]
        public IObjectResolver diContainer;
        
        private IBinder _binder;

        private void Awake()
        {
            _binder = this.CreateBinder();
        }

        private void OnEnable()
        {
            _binder.Bind();
        }

        private void OnDisable()
        {
            _binder.Unbind();
        }

        private IBinder CreateBinder()
        {
            object view = this.viewBinding switch
            {
                BindingMode.FromInstance => this.view,
                BindingMode.FromResolve => this.diContainer.Resolve(this.viewType.GetClass()),
                _ => throw new Exception($"Binding type of view {this.viewBinding} is not found!")
            };

            object model = this.viewModelBinding switch
            {
                BindingMode.FromInstance => this.viewModel,
                BindingMode.FromResolve => this.diContainer.Resolve(this.viewModelType.GetClass()),
                _ => throw new Exception($"Binding type of view {this.viewBinding} is not found!")
            };

            return BinderFactory.CreateComposite(view, model);
        }
    }
}