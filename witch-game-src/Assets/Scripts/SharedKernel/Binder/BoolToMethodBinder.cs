using System;
using MVVM;
using R3;

namespace SharedKernel.Binder
{
    public class BoolToMethodBinder : Observer<bool>, IBinder
    {
        private Action<bool> _view;
        private ReadOnlyReactiveProperty<bool> _property;
        private IDisposable _handle;

        public BoolToMethodBinder(Action<bool> view, ReadOnlyReactiveProperty<bool> property)
        {
            _view = view;
            _property = property;
        }
        public void Bind()
        {
            OnNext(_property.CurrentValue);
            _handle = _property.Subscribe(this);
        }

        public void Unbind()
        {
            _handle?.Dispose();
            _handle = null;
        }

        protected override void OnNextCore(bool value)
        {
            _view.Invoke(value);
        }

        protected override void OnErrorResumeCore(Exception error)
        {
            throw new NotImplementedException();
        }

        protected override void OnCompletedCore(Result result)
        {
            throw new NotImplementedException();
        }
    }
}