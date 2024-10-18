using System;
using Model.ScriptableObjects;
using MVVM;

namespace Infrastructure.Binders
{
    public class LookItemPropertiesBinder : IBinder
    {
        private readonly LookItemProperties _view;
        private readonly Action<LookItemProperties> _viewModelAction;

        public LookItemPropertiesBinder(LookItemProperties view, Action<LookItemProperties> viewModelAction)
        {
            _view = view;
            _viewModelAction = viewModelAction;
        }
        
        public void Bind()
        {
            _viewModelAction.Invoke(_view);
        }

        public void Unbind()
        {
            throw new NotImplementedException();
        }
    }
}